<template>
<q-page>

    <div class="peliculas-container">
        <div class="titulo-wrapper">
            <p class="titulo">Listado <span class="marca">Check<span>Flix</span></span></p>
            <p class="subtitulo">CheckFlix es una aplicación para checar películas y series</p>
        </div>

        <div v-for="(peli, index) in peliculas" :key="index">
            <Pelicula :title="peli.title" :duration="peli.duration" :categorie="peli.categorie" :director="peli.director" :poster="peli.poster" />
        </div>
    </div>

</q-page>
</template>

<script>
import Pelicula from 'components/Pelicula.vue';
import { onMounted } from '@vue/runtime-core';

const peliculas = [{
        id: 1,
        title: 'Shrek 2',
        duration: 2.24,
        categorie: 'Aventura',
        director: '',
        poster: ''
    },
    {
        id: 2,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        director: 'Fresia Perez',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    }
];

export default {
    name: 'Catalogo',
    components: {
        Pelicula
    },
    setup() {

        onMounted(async () => {
            console.log('Catalogo mounted');

        });

        return {
            peliculas
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
