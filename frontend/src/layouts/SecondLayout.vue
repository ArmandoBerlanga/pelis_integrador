<template>
<q-layout view="lHh lpr lFf">
    
    <q-header elevated class="header">
        <q-toolbar class="toolbar">

            <q-toolbar-title class="tittle">
                Check<span>Flix</span>
                <img src="~assets/checkmark.png" alt="checkmark icon" class="img-checkmark">
            </q-toolbar-title>
  
        </q-toolbar>
    </q-header>

    <q-page-container>
        <router-view />
    </q-page-container>

</q-layout>
</template>

<script>


export default {
    name: 'SecondLayout',
   
    setup() {
    
        return {       
        }
    }
}
</script>

<style lang="scss" scoped>
.header {
    padding: 0 1.5%;

    .toolbar {
        display: grid;
        grid-template-columns: 1fr auto;

        .tittle {
            font-size: 2.2em;
            padding: 0.5rem 0;

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
    }
}
</style>
