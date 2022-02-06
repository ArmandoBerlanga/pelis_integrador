<template>
  <router-view />
</template>
<script>
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'App'
})
</script>

<style lang="scss">
body{
  background-image: url("assets/bg.jpg");
  backdrop-filter: blur(6px);
  color: #0F0326;
}
  
</style>
