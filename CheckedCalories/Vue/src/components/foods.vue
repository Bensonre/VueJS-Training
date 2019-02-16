<template>
  <div class="foods">
    <img src="../assets/pie.gif" :alt="imgDes"> <!-- seems to no work with v-binding source have to check to see how images are being served-->
    <div class="food-nav">
    <h1 v-for="(food, index) in Food"
         :key="food.Id"
         class="foodtypes"
         @mouseover="updateProduct(index)">
    {{food.type}}
    </h1>
    </div>
    <div>
      <div>
        <h2>Food: {{currFood.type}}</h2>
        <div>
          <div>
            <span class="section-title"><em>Description:</em>{{currFood.des}}</span>
          </div>
          <div>
          <span v-if="currFood.CalCount"><em>Calories:</em>{{currFood.CalCount}}</span>
          <form v-else>
            <p>
              <div class= "warn"><em>Calories not found!</em></div>
              <label for="Calories">Input Calories:</label>
              <input id="Calories" v-model.number.lazy="currFood.CalCount" placeholder="0">
            </p>
          </form>
          </div>
          <div>
          <span><em>Taste: </em>{{currFood.taste}}</span>
          </div>
        </div>
      </div>
    </div>
    <div class="review-section">
    <div>
    <h2 class="tab-select">Make a Review</h2>
    <review-form @review-submitted="updateReview"></review-form>
    </div>
    <div>
    <h2 class="tab-select"> Reviews </h2>
    <review-list @deleteThis="deleteThis" :Food="currReveiws"></review-list>
    </div>
    </div>
  </div>
</template>

<script>
  import Reviews from './Reviews.vue'
  import ReviewsList from './ReviewsList.vue';
  import api from '../Api.js'
export default {
  name: 'foods',
  data () {
    return {
      selectedFood:0,
      Food: [
        {
          type: 'Pie',
          image: '/assets/pie.gif',
          ID: 314,
          des: 'A Pie',
          CalCount: 600,
          taste: 'Beyond',
          reviews: []
        },
        {
          type: 'Sushi',
          image: './assets/pie.png',
          ID: 315,
          des: 'Sushi',
          CalCount: 340,
          taste: 'Best',
          reviews: []
        },
        {
          type: 'Burger',
          image: './assets/pie.jpg',
          ID: 316,
          des: 'One juicy Burger Boi',
          CalCount: 750,
          taste: 'Delicious',
          reviews: []
        },
        {
          type: 'Day Old Oatmeal',
          image: './assets/pie.jpg',
          ID: 317,
          des: 'Woulda been good yesterday',
          CalCount: 0,
          taste: 'meh',
          reviews: []
        },
        ]

    }
    },
    computed: {
      image() {
        return this.Food[this.selectedFood].image
      },
      imgDes() {
        return this.Food[this.selectedFood].des
      },
      currFood() {
        return this.Food[this.selectedFood]
      },
      currReveiws(){
       return this.Food[this.selectedFood].reviews
      }

    },
      async created() {
      this.getAll()
      },

    methods: {
      updateProduct: function (index) {
        this.selectedFood = index
        console.log(index)
      },
      updateReview: async function (productReview) {
             this.Food[this.selectedFood].reviews.push(productReview)
             let ID= parseInt(this.currFood.ID.toString() + this.currFood.reviews.length.toString())
             await api.create(this.currFood.ID, ID, productReview)
       },
      async deleteThis(index){
            let ID= parseInt(this.currFood.ID.toString() + (index+1).toString())
            this.currFood.reviews.splice(index,1);
            await api.delete(ID);
       },
       getAll: async function (){
         const reviews = await api.getAll();
         let i=0
        for (i=0; i<this.Food.length; i++){
          const FoodID= this.Food[i].ID;
           this.Food[i].reviews= reviews.filter( review => review.foodId == this.Food[i].ID); 
         };
       }
    },
    components: {
      "review-form":Reviews,
      "review-list":ReviewsList
    },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
  .food-nav {
    display: flex;
    align-items: center;
    justify-content: center;
  }
  .warn{
    color:rgb(170, 48, 48);
  }
h1 {
  font-weight: normal;
  margin: 10px;
  text-decoration:underline;
}
h2{
  font-weight:normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #35495E;
}
.review-section{
  margin-top: 50px;
  text-align: start;
  display: flex;
  justify-content: center;
}
.tab-select{
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
  background-color: antiquewhite;
  text-align: center;
  margin: 10px;
  padding: 3px;
}
</style>
