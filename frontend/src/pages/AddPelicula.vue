<template>
    <div id="add_pelicula">
        <h1>VOY A AÑADIR UNA PELICULA!</h1>
        <p>
            <label for="nombre">Nombre de la pelicula:</label>
            <input type="text" id="nombre" v-model="nombrePelicula" />
        </p>


        <p>
            <label for="director">Nombre del director:</label>
            <input type="text" id="director" v-model="nombreDirector" />
        </p>


        <button @click="this.$router.push('/')">REGRESAR</button>




    </div>
</template>
<script>
export default {
    
}
</script>
<style lang="">
    
</style>