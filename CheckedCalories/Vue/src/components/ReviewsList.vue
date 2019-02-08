<template>
<div>
        <ul>
            <li v-for="(review, index) in reviews" :key=index>
         <div>Name: {{review.name}}</div>
         <div>Review: {{review.review}}</div>
         <div>Rating: {{review.rating}}</div>
            </li>
        </ul>
</div>
</template>

<script>
  export default{
    name: 'review-list',
    props:{
        reviews: {
            type:Array,
            default: function () {
                return {
                      reviews:[
                        {
                            name: 'Reese', 
                            review: 'good', 
                            rating: 0
                        }
                      ]
                    }
            }
        }
    }
  }
</script>
<style>

</style>
