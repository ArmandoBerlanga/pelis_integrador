<template>
<div id="pelicula">
    <div class="poster">
        <img :src="poster != '' ? poster: require('assets/nodisponible.png')" :alt="'poster de la pelicula ' + title">

        <p class="categoria">{{ categorie }}</p>
        <p class="director">Director@: {{ director == '' ? 'no asignado' : director }}</p>
    </div>

    <div class="info">
        <p class="title">{{ title }}</p>
        <p class="duration">{{ formatterDuration(duration) }}</p>
    </div>
</div>
</template>

<script>
export default {
    name: 'Pelicula',
    props: {
        title: {
            type: String,
            default: ''
        },
        duration: {
            type: Number,
            default: 0
        },
        categorie: {
            type: String,
            default: ''
        },
        director: {
            type: String,
            default: 'no registrado'
        },
        poster: {
            type: String,
            default: require('assets/nodisponible.png')
        }
    },
    setup() {

        function formatterDuration(duration) {
            let horas = Math.floor(duration);
            let minutos = Math.floor((duration - horas) * 60);
            return `${horas}h ${minutos}m`;
        }

        return {
            formatterDuration
        }
    }

}
</script>

<style lang="scss" scoped>
* {
    margin: 0;
    padding: 0;
}

#pelicula {
    display: flex;
    flex-flow: column nowrap;
    justify-content: center;
    align-items: center;
    transition: transform 0.45s ease;
    padding: 5% 0;

    .poster {
        position: relative;

        img {
            width: 13rem;
            height: 20rem;
            object-fit: cover;
            border-radius: 5px;
        }

        .categoria {
            position: absolute;
            top: 0;
            left: 0;
            background: rgba(0, 0, 0, 0.5);
            color: #fff;
            font-weight: bold;
            padding: 0.5rem;
            border-radius: 5px 0 5px 0;
            font-size: 0.8rem;
        }

        .director {
            position: absolute;
            bottom: 0;
            left: 0;
            width: 100%;
            background: rgba(0, 0, 0, 0.5);
            color: #fff;
            font-weight: bold;
            padding: 0.5rem;
            border-radius: 0 0 5px 5px;
            font-size: 0.8rem;

        }
    }

    .info {
        text-align: center;
        font-size: 1.2rem;

        .title {
            margin-top: 0.35rem;
            padding: 0 2.5rem;
            font-weight: bold;
        }

        .duration {
            color: grey;
            font-style: italic;
        }
    }

    &:hover {
        transform: scale(1.05);
        cursor: pointer;
        border-radius: 5px;
        background-color: rgba(128, 128, 128, 0.137);
    }
}
</style>
