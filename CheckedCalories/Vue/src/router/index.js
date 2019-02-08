import Vue from 'vue'
import Router from 'vue-router'
import foods from '@/components/foods'
import Reviews from '@/components/Reviews'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'foods',
      component: foods
    },
    {
      path: '/r',
      name: 'review-form',
      component: Reviews
    }
  ]
})
