<template>
<div class="protagonistas">
    <q-table title="Lista de protagonistas" :rows="state.rows" :columns="state.columns" row-key="protagonistaId" no-data-label="Sin datos" />
    <div class="botones">
        <q-btn @click="addActor()" icon="add" />
        <q-btn @click="deleteActor()" icon="delete" />
    </div>
</div>
</template>

<script>
import {
    onMounted,
    reactive,
    computed
} from '@vue/runtime-core';
import {
    useQuasar
} from 'quasar';
import {
    api
} from 'boot/axios';
import {
    useRoute
} from "vue-router";

export default {
    name: 'TablaProtagonistas',
    setup(props, cxt) {

        const $q = useQuasar()

        const route = useRoute();
        const id = computed(() => route.params.id).value;

        const columns = [{
                name: 'protagonistaId',
                required: true,
                label: 'Identificador',
                align: 'left',
                field: row => row.protagonistaId,
                format: val => `${val}`,
                sortable: true
            },
            {
                name: 'nombreProtagonista',
                align: 'right',
                label: 'Nombre del protagonista',
                field: 'nombreProtagonista',
                sortable: true
            }
        ]

        const rows = [];

        const state = reactive({
            rows: rows,
            columns: columns,
        });

        onMounted(async () => {
        })

        function deleteActor() {
            $q.dialog({
                dark: false,
                title: 'Borrar actor por IDENTIFICADOR',
                message: '¿Estas seguro?',
                prompt: {
                    model: '',
                    type: 'number' // optional
                },
                cancel: true,
                persistent: true
            }).onOk(data => {

                state.rows.splice(state.rows.findIndex(row => row.protagonistaId === data), 1);
                cxt.emit('listaActores', state.rows);

            }).onCancel(() => {}).onDismiss(() => {})
        }

        function addActor() {
            $q.dialog({
                dark: false,
                title: 'Añadir actor',
                message: 'Ingrese el nombre del actor a agregar',
                prompt: {
                    model: '',
                    type: 'text' // optional
                },
                cancel: true,
                persistent: true
            }).onOk(data => {

                let existe = state.rows.filter(
                    d => d.nombreProtagonista.toLowerCase() === data.toLowerCase()).length === 0;

                if (existe) {
                    if (data.length > 30) {
                        $q.notify({
                            message: 'El nombre del actor no puede superar los 30 caracteres',
                            color: 'primary'
                        })
                        return;
                    }

                    state.rows.push({
                        protagonistaId: data.length * 2,
                        nombreProtagonista: data
                    })

                    cxt.emit('listaActores', state.rows);

                } else
                    $q.notify({
                        message: 'Actor ya existe',
                        color: 'primary'
                    })

            }).onCancel(() => {}).onDismiss(() => {})

        }

        return {
            state,
            deleteActor,
            addActor
        }

    }

}
</script>

<style lang="scss" scoped>
.protagonistas {
    grid-column: 1/-1;
    display: grid;
    grid-template-columns: 1fr 0.07fr;
    gap: 0.35rem;

    .botones {
        display: flex;
        flex-flow: column nowrap;
        gap: 0.35rem;
    }
}
</style>
