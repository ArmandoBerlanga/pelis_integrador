<template>
    <div id="add_pelicula">
        <div class="titulo-wrapper">
            <div class="content">
                <p class="titulo">Sección para agregar peliculas</p>
                
            </div>
             <button @click="this.$router.push('/')">REGRESAR</button>
        </div>

        <form class="form-holder" @submit.prevent="onSubmit()">
            <p class="subtitulo">CheckFlix es una aplicación para checar películas y series</p>

            <div class="content">

                <div class="campo-poster">
                    <label for="poster">Poster</label>
                    <!-- todo el proceso de lo de base64 -->
                    <input type="text" name="poster" v-model="state.pelicula.poster" placeholder="poster" />
                </div>

                <div class="datos">
                    <div class="campo">
                        <label for="nombre">Nombre de la pelicula</label>
                        <input type="text" name="nombre" v-model="state.pelicula.nombrePelicula" required>
                    </div>

                    <div class="campo">
                        <label for="duracion">Duración</label>
                        <input type="number" name="duracion" v-model="state.pelicula.duracion" required>
                    </div>

                    <div class="campo">
                        <select name="categoria" id="categoria" required>
                            <option value="">Seleccione una categoria</option>
                            <option value="Accion">Acción</option>
                            <option value="Comedia">Comedia</option>
                            <option value="Drama">Drama</option>
                            <option value="Terror">Terror</option>
                            <option value="Suspenso">Suspenso</option>
                            <option value="Ciencia ficcion">Ciencia ficcion</option>
                            <option value="Romance">Romance</option>
                            <option value="Fantasia">Fantasia</option>
                            <option value="Animacion">Animación</option>
                            <option value="Documental">Documental</option>
                            <option value="Musical">Musical</option>
                            <option value="Western">Western</option>
                            <option value="Otros">Otros</option>
                        </select>
                    </div>
                </div>

            </div>


            
        </form>
        
       

    </div>
</template>

<script>
import { reactive } from '@vue/runtime-core';

export default {
    name:'AddPelicula',
    setup(){
        document.title = 'Añadir Pelicula';

        const state = reactive({
            pelicula: {
                nombrePelicula: '',
                duracion: 0,
                descripcionCorta: '',
                nombreDirector: '',
                poster: '',
                categoria: '',
                fechaEstreno: '',
            }
        });

        function onSubmit(){
            console.log('submit');
        }

        return{
            state,
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
    
</style>