<template>
  <div class="foods" >
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
          <span v-if="currFood.CalCount"><em>calories:</em>{{currFood.CalCount}}</span>
          <form v-else>
            <p>
              <em>Calories not found!</em>
              <label for="Calories">Input Calories:</label>
              <input id="Calories" v-model.number.lazy="currFood.CalCount" placeholder="0">
            </p>
          </form>
          <div>
          <span><em>Taste: </em>{{currFood.taste}}</span>
          </div>
          </div>

        </div>
      </div>
    </div>
    <div class="review-section">
    <div>
    <h2 class="tab-select">Make a Review</h2>
    <review-form @review-submitted="updateReviews"></review-form>
    </div>
    <div>
    <h2 class="tab-select"> Reviews </h2>
    <review-list :reveiws="currFood.reviews"></review-list>
    </div>
    </div>
  </div>
</template>

<script>
  import Reviews from './Reviews.vue'
  import ReviewsList from './ReviewsList.vue';
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
          reviews: [
            { 
             name: "Reese",
             review:"love",
             rating:"5"
            }
          ]
        },
        {
          type: 'Sushi',
          image: './assets/pie.png',
          ID: 315,
          des: 'Sushi',
          CalCount: 340,
          taste: 'Best',
          reviews: [
            {
             name: null,
             review:null,
             rating:null
            }

          ]
        },
        {
          type: 'Burger',
          image: './assets/pie.jpg',
          ID: 316,
          des: 'One juicy Burger Boi',
          CalCount: 750,
          taste: 'Delicious',
          reviews: [
            {
             name: null,
             review:null,
             rating:null
            }
          ]
        },
        {
          type: 'Day Old Oatmeal',
          image: './assets/pie.jpg',
          ID: 317,
          des: 'Woulda been good yesterday',
          CalCount: 0,
          taste: 'meh',
          reviews: [
            {
             name: null,
             review:null,
             rating:null
            }
          ]
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

    },
    methods: {
      updateProduct: function (index) {
        this.selectedFood = index
        console.log(index)
      },
      updateReviews(productReview){
            this.Food[this.selectedFood].reviews.push(productReview)
      }
    },
    components: {
      "review-form":Reviews,
      "review-list":ReviewsList
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
  .food-nav {
    display: flex;
    align-items: center;
    justify-content: center;
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
