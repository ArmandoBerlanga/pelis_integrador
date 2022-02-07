<template>
<div class="search-bar">
    <q-icon name="search" class="search-icon" />
    <input type="text" v-model="state.userAnswer" placeholder="Busca tu peli fav ...." @change="updateInput">
</div>
</template>

<script>
import {
    reactive
} from '@vue/reactivity';
import {
    watch
} from 'vue'

export default {
    name: 'Filtrado',
    setup(props, context) {

        const state = reactive({
            userAnswer: '',
        });

        function updateInput() {
            context.emit('userTyping', state.userAnswer)
        }

        watch(() => state.userAnswer, (viejo, nuevo) => {
            if (viejo != nuevo)
                updateInput();
        });

        return {
            state,
            updateInput
        }
    },
};
</script>

<style lang="scss" scoped>
.search-bar {
    background-color: white;
    border-radius: 5px;
    color: grey;
    display: flex;
    align-items: center;

    .search-icon {
        font-size: 1.5rem;
        padding: 0.5rem;
    }

    input {
        border: none;
        padding: 0.7rem 0;
        font-size: 1rem;
        width: 20rem;
        border-radius: 5px;

        &:focus {
            outline: none;
        }
    }
}
</style>
