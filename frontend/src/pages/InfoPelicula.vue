<template>
<div id="info-pelicula">

</div>
</template>

<script>
import { reactive } from '@vue/reactivity';
import { onMounted } from '@vue/runtime-core';
export default {

    name: 'InfoPelicula',
    setup() {
        document.title = 'CheckFlix';

        const state = reactive({
            pelicula: null
        });

        onMounted(async () => {
            const response = await api.get('/Pelicula/' + this.$route.params.id);
            state.pelicula = response.data;
        });

        return {
            state
        }
    }
}
</script>

<style lang="">
    
</style>
