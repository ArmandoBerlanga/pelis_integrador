<template>
<q-page>

    <div class="titulo-wrapper">
        <p class="titulo">Listado <span class="marca">Check<span>Flix</span></span></p>
        <p class="subtitulo">CheckFlix es una aplicación para checar películas y series</p>
        <!-- <q-pagination class="pagination" v-model="state.current" :max="5" /> -->
    </div>

    <div class="peliculas-container">
        <div v-for="(peli, index) in pelisFiltradas" :key="index">
            <Pelicula :id="peli.peliculaId" :title="peli.nombrePelicula" :duration="peli.duracion" :categorie="peli.descripcionCorta" :director="peli.nombreDirector == null ? '' : peli.nombreDirector" :poster="peli.poster == null ? '' : peli.poster" />
        </div>
    </div>

</q-page>
</template>

<script>
import Pelicula from 'components/Pelicula.vue';
import {
    reactive
} from '@vue/runtime-core';

export default {
    name: 'Catalogo',
    components: {
        Pelicula
    },
    props: {
        pelisFiltradas: Array
    },
    setup() {
        document.title = 'CheckFlix';

        const state = reactive({
            current: 1
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

.titulo-wrapper {
    margin: 0 3rem;
    margin-top: 0.7rem;

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

    .pagination {
        margin-top: 1rem;
        display: grid;
        place-items: center;
    }
}

.peliculas-container {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    padding: 0.7rem;
}
</style>
