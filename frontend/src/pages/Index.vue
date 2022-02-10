<template>
<q-page>

    <div class="peliculas-container">
        <div class="titulo-wrapper">
            <p class="titulo">Listado <span class="marca">Check<span>Flix</span></span></p>
            <p class="subtitulo">CheckFlix es una aplicación para checar películas y series</p>
        </div>

        <div v-for="(peli, index) in pelisFiltradas" :key="index">
            <Pelicula 
                :id="peli.peliculaId"
                :title="peli.nombrePelicula" :duration="peli.duracion" 
                :categorie="peli.descripcionCorta" 
                :director="peli.nombreDirector == null ? '' : peli.nombreDirector" 
                :poster="peli.poster == null ? '' : peli.poster" 
            />
        </div>
    </div>

</q-page>
</template>

<script>
import Pelicula from 'components/Pelicula.vue';
import { reactive } from '@vue/runtime-core';

export default {
    name: 'Catalogo',
    components: {
        Pelicula
    },
    props:{
        pelisFiltradas: Array
    },
    setup() {
        document.title = 'CheckFlix';

        const state = reactive({
        });

        return {
            state
        }
    }

}
</script>

<style lang="scss" scoped>
* {
    margin: 0;
    padding: 0;
}

.peliculas-container {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    gap: 0.5rem;
    padding: 1rem;
    padding-top: 0.7rem;

    .titulo-wrapper {
        grid-column: 1/-1;
        margin-top: 0.7rem;
        margin: 0 1rem;

        .titulo {
            font-size: 2rem;
            font-weight: bold;

            .marca {
                font-style: italic;

                span {
                    color: #E9C46A;
                }
            }

        }

        .subtitulo {
            font-size: 1.4rem;
            font-style: italic;

            span {
                font-weight: bold;
            }
        }
    }
}
</style>
