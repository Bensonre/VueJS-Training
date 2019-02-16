<template>
    <form class="review-form" @submit.prevent="onSubmit">

      <p v-if="errors.length">
        <b>Please correct the following error(s)</b>
        <ul>
          <li for v-for="error in errors"> {{error}} </li>
        </ul>
      </p>

      <p>
        <label for="name">Name:</label>
        <input id="name" v-model="name" placeholder="name">
      </p>

      <p>
        <label for="text">Review:</label>
        <textarea id="text" v-model="text"></textarea>
      </p>

      <p>
        <label for="rating">Rating:</label>
        <select id="rating" v-model.number="rating">
          <option>5</option>
          <option>4</option>
          <option>3</option>
          <option>2</option>
          <option>1</option>
        </select>
      </p>

      <p>
        <input type="submit" value="Submit">
      </p>

    </form>
</template>

<script>
  export default{
    name: 'review-form',
    data(){
      return{
        name: null,
        text:null,
        rating:null,
        errors: []
      }
    },
    methods: {
        onSubmit(){
            if (this.name && this.text && this.rating){
              let productReview = {
                name: this.name,
                text: this.text,
                rating: this.rating
                }
                this.$emit('review-submitted', productReview)
                this.name=null
                this.text= null
                this.rating= null
            }
            else{
                if (!this.name) this.errors.push("Name required.")
                if (!this.text) this.errors.push("Review required.")
                if (!this.rating) this.errors.push("Rating required.")
            }
        }
    }
  }
</script>
<style>
p{
  width: 200px;
  padding: 5px;
}
</style>

