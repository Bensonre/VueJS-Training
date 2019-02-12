<template>
<div>
        <ul v-if="Food.length">
            <li v-for="(review, index) in Food" :key=index>
         <div>Name: {{review.name}}</div>
         <div>Review: {{review.review}}</div>
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
    }
  }
</script>
<style>

</style>
