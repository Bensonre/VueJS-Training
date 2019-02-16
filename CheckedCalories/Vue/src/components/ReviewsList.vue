<template>
<div>
        <ul v-if="Food.length">
            <li v-for="(review, index) in Food" :key=index>
              <div class="remove" @click="deleteThis(index)">X</div>
         <div>Name: {{review.name}}</div>
         <div>Review: {{review.text}}</div>
         <div>Rating: {{review.rating}}</div>
            </li>
        </ul>
        <div v-else>No Reviews Yet!</div>
</div>
</template>

<script>
  export default{
    name: 'review-list',
    props:{
        Food: {
          type: Array
        }
    },
    methods: {
      deleteThis: function (index){
          this.$emit("deleteThis",index);
      }
    }
  }
</script>
<style>
.remove{
  justify-content: left;
  text-align: Right;
  color:rgb(170, 48, 48);
}
</style>
