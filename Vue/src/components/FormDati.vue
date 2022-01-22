<template>
    <div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Inserire il numero</label>
            <br>
            <input type="number" v-model="inputDati">
        </div>
        <button type="submit" class="btn btn-primary" @click="FetchData()">Submit</button>
        <div v-if="response.length!=0">
            <div class="gallery">
                <div class="gallery-panel" v-for="photo in response" :key="photo">
                    <img :src="photo">    
                        <button type="submit" class="btn btn-primary form-control" data-toggle="modal" data-target="#exampleModal" style="border-radius: 0.50rem" @click="SaveShibaDb(photo)">Save</button>
                    </div>
            </div>
        </div>
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" :style="'color:' + ColoreNotifica()">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Notifica</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">{{response2}}</div>
                    <div class="modal-footer">
                        <button type="button" class="btn text-white"  :style="'background:' + ColoreNotifica()" data-dismiss="modal">Close</button>
                    </div>
                    </div>
                </div>
            </div>
         </div>    
</template>

<script>
export default {
    name:"FormDati",
    data(){
        return{
            inputDati:0,
            response:[],
            response2:"",
        }
    },
    methods: {
        FetchData(){
           const axios = require("axios");
        axios.post("http://localhost:63166/?numeroShiba="+this.inputDati)
        .then((response) => (this.response = response.data));
        },
        SaveShibaDb(item){
            const axios=require("axios");
            axios.post("http://localhost:63166/Shibas/Create/?url="+item)
            .then((response)=>(this.response2=response.data));
        },
        ColoreNotifica()
        {
            if(this.response2=="Aggiunto con sucesso al DataBase")
                return "green"
            else
            {
                if(this.response2=="Non Aggiunto al DataBase")
                    return "red"
            }

        }
    },  
}
</script>

<style>
  .gallery {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(20rem, 1fr));
    grid-gap: 1rem;
    max-width: 80rem;
    margin: 2rem auto;
    padding: 0 2rem;
  }

  .gallery-panel img {
    width: 100%;
    height: 22vw;
    object-fit: cover;
    border-radius: 0.75rem;
  }
</style>