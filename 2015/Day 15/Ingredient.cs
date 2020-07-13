using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
    class Ingredient
    {
        public int capacity, durability, flavor, texture, calories;
        public string name;

        public Ingredient(string name, int capacity, int durability, int flavor, int texture, int calories)
        {
            this.name = name;
            this.capacity = capacity;
            this.durability = durability;
            this.flavor = flavor;
            this.texture = texture;
            this.calories = calories;
        }

        public Ingredient(Ingredient baseIngredient, int ammount)
        {
            this.name = baseIngredient.name;
            this.capacity = baseIngredient.capacity * ammount;
            this.durability = baseIngredient.durability * ammount;
            this.flavor = baseIngredient.flavor * ammount;
            this.texture = baseIngredient.texture * ammount;
            this.calories = baseIngredient.calories * ammount;
        }
    }
}
