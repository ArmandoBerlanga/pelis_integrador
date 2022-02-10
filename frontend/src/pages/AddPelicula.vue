<template>
<div id="add_pelicula">

    <p class="titulo">Sección para agregar peliculas</p>

    <form class="form-holder" @submit.prevent="onSubmit()">
        <p class="subtitulo">Añade tu peli fav agregando toda su info!!</p>

        <div class="content">

            <div class="campo-poster">
                <img id="poster-fijo" src="~assets/nodisponible.png" alt="no disponible">
                <input type="file" @change="alterPoster">
            </div>

            <div class="datos">
                <div class="campo">
                    <label for="nombre">Nombre de la pelicula</label>
                    <q-input filled v-model="state.pelicula.nombrePelicula" label="Nombre" />
                </div>

                <div class="campo">
                    <label for="duracion">Duración</label>
                    <q-input filled v-model.number="state.pelicula.duracion" type="number" />
                </div>

                <div class="campo select categoria">
                    <label for="categoria">Categoría</label>
                    <div class="content">
                        <q-select filled v-model="state.pelicula.categoria" use-input input-debounce="0" label="Categoría" :options="state.optionsCategoria" @filter="filterFnCategoria" behavior="menu" />
                        <q-btn @click="submitCategoria()" class="add" icon="add" />
                    </div>
                </div>

                <div class="campo select director">
                    <label for="director">Director</label>
                    <div class="content">
                        <q-select filled v-model="state.pelicula.director" use-input input-debounce="0" label="Director" :options="state.optionsDirector" @filter="filterFnDirector" behavior="menu" />
                        <q-btn @click="submitDirector()" class="add" icon="add" />
                    </div>
                </div>

                <div class="campo botones">
                    <q-btn class="btn-normal" @click="this.$router.push('/')" outline style="color: grey;" label="REGRESAR" />
                    <q-btn class="btn-normal" @click="onSubmit()" color="secondary" label="GUARDAR" />
                </div>

            </div>

        </div>

    </form>

</div>
</template>

<script>
import {
    onMounted,
    reactive
} from '@vue/runtime-core';
import {
    useQuasar
} from 'quasar';
import {
    api
} from 'boot/axios';

export default {
    name: 'AddPelicula',
    setup() {
        document.title = 'Añadir Pelicula';
        const $q = useQuasar()

        const state = reactive({
            pelicula: {
                nombrePelicula: '',
                duracion: 0,
                director: '',
                categoria: '',
                poster: ''
            },
            //categorias
            responseCategorias: null,
            optionsCategoria: [],
            copiaOptionsCategoria: [],

            //directores
            responseDirectores: null,
            optionsDirector: [],
            copiaOptionsDirector: [],
        });

        onMounted(async () => {

            // categorias
            const responseCategorias = await api.get('/Categoria');
            state.responseCategorias = responseCategorias.data;
            responseCategorias.data.forEach(categoria => state.optionsCategoria.push(categoria.descripcionCorta));

            // directores
            const responseDirectores = await api.get('/Director');
            state.responseDirectores = responseDirectores.data;
            responseDirectores.data.forEach(director => state.optionsDirector.push(director.nombreDirector));

            // copias
            state.copiaOptionsCategoria = state.optionsCategoria;
            state.copiaOptionsDirector = state.optionsDirector;
        });

        function filterFnCategoria(val, update) {
            if (val === '') {
                update(() => {
                    state.optionsCategoria = state.copiaOptionsCategoria;
                })
                return
            }

            update(() => {
                const needle = val.toLowerCase()
                state.optionsCategoria = state.copiaOptionsCategoria.filter(v => v.toLowerCase().indexOf(needle) > -1)
            })
        }

        function filterFnDirector(val, update) {
            if (val === '') {
                update(() => {
                    state.optionsDirector = state.copiaOptionsDirector;
                })
                return
            }

            update(() => {
                const needle = val.toLowerCase()
                state.optionsDirector = state.copiaOptionsDirector.filter(v => v.toLowerCase().indexOf(needle) > -1)
            })
        }

        function submitCategoria() {
            $q.dialog({
                dark: false,
                title: 'Agrege una categoria',
                message: 'Ingrese el nombre de la categoria',
                prompt: {
                    model: '',
                    type: 'text' // optional
                },
                cancel: true,
                persistent: true
            }).onOk(data => {

                let bool = state.responseCategorias.filter(
                    d => d.descripcionCorta.toLowerCase() === data.toLowerCase()).length === 0;

                if (bool) {

                    api.post('/Categoria', {
                        descripcionCorta: data,
                        descripcionLarga: "no por el momento"

                    }).then(response => {
                        state.responseCategorias.push(response.data);
                        state.optionsCategoria.push(response.data.descripcionCorta);

                        $q.notify({
                            message: 'Categoría agregada',
                            color: 'primary'
                        })

                    })
                } else
                    $q.notify({
                        message: 'Categoría ya existe',
                        color: 'primary'
                    })

            }).onCancel(() => {}).onDismiss(() => {})
        }

        function submitDirector() {
            $q.dialog({
                dark: false,
                title: 'Agrege un director',
                message: 'Ingrese el nombre del director',
                prompt: {
                    model: '',
                    type: 'text' // optional
                },
                cancel: true,
                persistent: true
            }).onOk(data => {

                let bool = state.responseDirectores.filter(
                    d => d.nombreDirector.toLowerCase() === data.toLowerCase()).length === 0;

                if (bool) {

                    api.post('/Director', {
                        nombreDirector: data

                    }).then(response => {
                        state.responseDirectores.push(response.data);
                        state.optionsDirector.push(response.data.nombreDirector);

                        $q.notify({
                            message: 'Director agregado',
                            color: 'primary'
                        })

                    })
                } else
                    $q.notify({
                        message: 'Director ya existe',
                        color: 'primary'
                    })

            }).onCancel(() => {}).onDismiss(() => {})
        }

        function getBase64(file) {
            return new Promise(function (resolve, reject) {
                var reader = new FileReader();
                reader.onload = function () {
                    resolve(reader.result);
                };
                reader.onerror = reject;
                reader.readAsDataURL(file);
            });
        }

        async function alterPoster(event) {
            let result = await getBase64(event.target.files[0]);
            state.pelicula.poster = result;

            let foto = document.getElementById('poster-fijo');
            foto.src = result;
            foto.style.width = '100%';
            foto.style.height = 'auto';
            foto.style.borderRadius = '5px';
            foto.style.objectFit = 'cover';
        }

        function onSubmit() {

            if (state.pelicula.nombrePelicula === '') {
                $q.notify({
                    message: 'Ingrese el nombre de la pelicula',
                    color: 'primary'
                })
                return
            }

            if (state.pelicula.duracion === 0) {
                $q.notify({
                    message: 'Ingrese la duracion de la pelicula',
                    color: 'primary'
                })
                return
            }

            if (state.pelicula.categoria === '') {
                $q.notify({
                    message: 'Ingrese la categoria de la pelicula',
                    color: 'primary'
                })
                return
            }

            if (state.pelicula.director === '') {
                $q.notify({
                    message: 'Ingrese el director de la pelicula',
                    color: 'primary'
                })
                return
            }

            let params = {
                PeliculaID: 0,
                NombrePelicula: state.pelicula.nombrePelicula,
                Duracion: state.pelicula.duracion,
                CategoriaID:  state.responseCategorias.filter(c => c.descripcionCorta === state.pelicula.categoria)[0]?.categoriaId ?? null,
                DirectorID: state.responseDirectores.filter(d => d.nombreDirector === state.pelicula.director)[0]?.directorId ?? null,
                Poster: state.pelicula.poster
            }
    
            api.post('/Pelicula', params).then(response => {
                $q.notify({
                    message: 'Pelicula agregada',
                    color: 'primary'
                })
            })

        }

        return {
            state,
            filterFnCategoria,
            filterFnDirector,
            submitCategoria,
            submitDirector,
            alterPoster,
            onSubmit
        }
    }

}
</script>

<style lang="scss" scoped>
* {
    margin: 0;
    padding: 0;
}

#add_pelicula {
    display: flex;
    flex-direction: column;
    width: 60%;
    background-color: white;
    border: 2px solid rgba(204, 204, 204, 0.192);
    border-radius: 5px;
    margin: 4rem auto;
    padding: 2rem;
}

.titulo {
    color: #0F0326;
    font-size: 1.5rem;
    font-weight: bold;
}

.subtitulo {
    color: #0F0326;
    font-size: 1rem;
    margin-bottom: 0.7rem;
}

.form-holder .content {
    display: grid;
    grid-template-columns: 0.6fr 1fr;
    gap: 1rem;

    .campo-poster {
        img {
            width: 100%;
            height: auto;
            border-radius: 5px;
        }
    }

    .datos {

        .campo {
            margin-bottom: 0.35rem;

            label {
                color: #0F0326;
                font-size: 0.9rem;
                font-weight: bold;
            }
        }

        .select {
            .add {
                background-color: #220753;
                color: white;
            }

            .content {
                display: grid;
                grid-template-columns: 8fr 1fr;
                gap: 0.35rem;
            }
        }

        .botones {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 0.35rem;
            margin-top: 1.4rem;
        }
    }

    .btn-normal {
        padding: 0.5rem;
    }

}
</style>
