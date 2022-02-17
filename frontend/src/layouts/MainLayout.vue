<template>
<q-layout view="hHh Lpr fFf">
    
    <q-header elevated class="header">
        <q-toolbar class="toolbar">

            <div class="tittle" @click="this.$router.push('/')">
                Check<span>Flix</span>
                <img src="~assets/checkmark.png" alt="checkmark icon" class="img-checkmark">
            </div>

            <div class="extra-tools">
                <q-btn round color="secondary" icon="add" @click="this.$router.push('/add')"/>
                <SearchBar @userTyping="filter"/>
            </div>
            
        </q-toolbar>
    </q-header>

    <q-page-container>
        <router-view :pelisFiltradas="state.listaFiltrada"/>
    </q-page-container>

</q-layout>
</template>

<script>
import SearchBar from 'components/SearchBar.vue'
import { onMounted, reactive } from '@vue/runtime-core';
import { api } from 'boot/axios';

export default {
    name: 'MainLayout',
    components:{
        SearchBar
    },
    setup() {
      
        const state = reactive({
            listaOriginal: [],
            listaFiltrada: []
        });

        onMounted(async () => {   
            const response = await api.get('/Pelicula');
            state.listaOriginal = response.data.sort((a, b) => a.nombrePelicula.localeCompare(b.nombrePelicula));
       
            state.listaFiltrada = state.listaOriginal;
        });

        function filter(out){
            state.listaFiltrada = state.listaOriginal;

            state.listaFiltrada = state.listaFiltrada.filter(peli => 
                peli.nombrePelicula.toLowerCase().includes(out.toLowerCase()) ||
                peli.nombreDirector?.toLowerCase().includes(out.toLowerCase()) ||
                peli.descripcionCorta.toLowerCase().includes(out.toLowerCase())
            ).sort((a, b) => a.nombrePelicula.localeCompare(b.nombrePelicula));
        }

        return {
            state,
            filter
        }
    }
}
</script>

<style lang="scss" scoped>
.header {
    padding: 0 1.5%;

    .toolbar {
        display: flex;
        justify-content: space-between;

        .tittle {
            font-size: 2.2em;
            cursor: pointer;

            span {
                font-weight: bold;
                color: #E9C46A;
                font-style: italic;
            }

            .img-checkmark {
                filter: invert(69%) sepia(98%) saturate(221%) hue-rotate(1deg) brightness(98%) contrast(89%);
                width: 22px;
                height: 22px;
                position: absolute;
                top: 0.21rem;
                left: 7.85rem;
            }
        }

        .extra-tools {
            display: flex;
            align-items: center;
            gap: 0.7rem;
            padding: 0.5rem 0;
            
        }
    }
}
</style>
