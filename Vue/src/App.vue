<template>
  <div class="container">
    <h1 class="mt-5">ShibaImage.com</h1>
    <FormDati></FormDati>
  </div>
</template>

<script>
import FormDati from './components/FormDati.vue'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'jquery/src/jquery.js'
import 'bootstrap/dist/js/bootstrap.min.js'
import 'axios/dist/axios.min.js'

export default {
  name: 'App',
  components: {
    FormDati
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
