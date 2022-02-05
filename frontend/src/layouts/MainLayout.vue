<template>
<q-layout view="lHh lpr lFf">
    <q-header elevated class="header">
        <q-toolbar class="toolbar">
            <q-toolbar-title class="tittle">
                Check<span>Flix</span>
                <img src="~assets/checkmark.png" alt="checkmark icon" class="img-checkmark">
            </q-toolbar-title>

            <div class="extra-tools">

                <q-btn round color="secondary" icon="add" />

                <q-input color="primary" bg-color="white" filled v-model="text" label="Busca tu pelicula fav...">
                    <template v-slot:prepend>
                        <q-icon name="search" />
                    </template>
                </q-input>

            </div>
        </q-toolbar>
    </q-header>

    <q-page-container>
        <router-view />
    </q-page-container>
</q-layout>
</template>

<script>
import {
    defineComponent
} from 'vue'

export default defineComponent({
    name: 'MainLayout',
    setup() {
        return {}
    }
})
</script>

<style lang="scss" scoped>
.header {
    padding: 0 1.5%;

    .toolbar {
        display: grid;
        grid-template-columns: 1fr auto;

        .tittle {
            font-size: 2.2em;

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
                top: 0.55rem;
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
