<template>
<div class="protagonistas">
    <q-table title="Lista de protagonistas" :rows="state.rows" :columns="state.columns" row-key="protagonistaId" />
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
import { useQuasar } from 'quasar';
import { api } from 'boot/axios';
import { useRoute } from "vue-router";

export default {
    name: 'TablaProtagonistas',
    setup() {

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

            const responseProtagonistas = await api.get(`/Protagonista/${id}`);
            state.rows = responseProtagonistas.data;

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

                api.delete('/Protagonista/' + id + '/' + data)
                    .then(async () => {
                        $q.notify({
                            message: 'Actor borrado',
                            color: 'primary'
                        });

                        const responseProtagonistas = await api.get(`/Protagonista/${id}`);
                        state.rows = responseProtagonistas.data;
                    })
                    .catch(error => {
                        $q.notify({
                            message: 'Error al borrar actor',
                            color: 'primary'
                        })
                    })

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

                    api.post(`/Protagonista?peliculaID=${id}&nombreProtagonista=${data}`)
                        .then(async () => {
                            $q.notify({
                                message: 'Actor agregado',
                                color: 'primary'
                            });

                            const responseProtagonistas = await api.get(`/Protagonista/${id}`);
                            state.rows = responseProtagonistas.data;
                        })

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
