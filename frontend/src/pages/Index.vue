<template>
<q-page>

    <div class="peliculas-container">
        <div class="titulo-wrapper">
            <p class="titulo">Listado CheckFlix</p>
            <p class="subtitulo">CheckFlix es una aplicación para checar películas y series</p>
            <!-- <p class="subtitulo"><span>CATEGORÍA: MIEDO</span> Resultados encontrados: 0</p> -->
        </div>

        <div v-for="(peli, index) in peliculas" :key="index">
            <Pelicula :title="peli.title" :duration="peli.duration" :categorie="peli.categorie" :poster="peli.poster" />
        </div>
    </div>

</q-page>
</template>

<script>
import Pelicula from 'components/Pelicula.vue';

const peliculas = [{
        id: 1,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 2,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 3,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 4,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 5,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 6,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 4,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 5,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 6,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 4,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 5,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 6,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 4,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 5,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 6,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 4,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 5,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 6,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 4,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 5,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 6,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 4,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 5,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    },
    {
        id: 6,
        title: 'The Shawshank Redemption',
        duration: 2.2,
        categorie: 'Horror',
        poster: 'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg'
    }
];

export default {
    name: 'Catalogo',
    components: {
        Pelicula
    },
    setup() {
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
    gap: 1rem;
    padding: 1rem;
    padding-top: 0.7rem;

    .titulo-wrapper {
        grid-column: 1/-1;
        margin-top: 0.7rem;
        margin: 0 1rem;
    
        .titulo {
            font-size: 2.5rem;
            font-weight: bold;
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
