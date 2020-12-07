import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Day7 {

    public static void main(String[] args) {
        List<String[]> input = AoC.inputRowsSplit(7, " ");
        List<Bag> bags = new ArrayList<>();

        //Creates bags
        for (String[] row : input) {
            Bag bag = new Bag();

            bag.color = row[0] + row[1];

            if (AoC.tryParseInt(row[4])) {

                for (int i = 4; i < row.length; i += 4) {
                    bag.canCarry.put(row[i + 1] + row[i + 2], Integer.parseInt(row[i]));
                }
            }

            bags.add(bag);
        }

        //Part 1
        List<String> containsShiny = containsBag("shinygold", bags);

        AoC.output(containsShiny.size());
        AoC.output(totalBagsIn("shinygold", bags));

    }

    static List<String> containsBag(String bagColor, List<Bag> bags) {
        List<String> contains = new ArrayList<>();

        for (Bag bag : bags) {
            //If the bag contains the target and we havent added it before
            if (bag.containsBag(bagColor) && !isInList(contains, bag.color)) {

                //Add bag
                contains.add(bag.color);

                //Those who can carry this bag
                List<String> canCarryParent = containsBag(bag.color, bags);

                //Adds those we havent seen before
                for(String otherColor : canCarryParent)
                    if(!isInList(contains, otherColor))
                        contains.add(otherColor);

            }
        }
        return contains;
    }

    static boolean isInList(List<String> list, String value) {
        for (String s : list)
            if (s.equals(value))
                return true;

        return false;
    }

    static int totalBagsIn(String bagColor, List<Bag> bags)
    {
        int total = 0;

        for(Bag bag : bags)
        {
            //Finds target bag
            if(bag.color.equals(bagColor))
            {
                total += bag.numOfSubBags();

                //Names of the bags the bag can carry
                for(String subBagColor : bag.canCarry.keySet())
                {
                    total += bag.canCarry.get(subBagColor) * totalBagsIn(subBagColor, bags);
                }
            }
        }

        return  total;
    }

    static class Bag {
        String color;
        Map<String, Integer> canCarry = new HashMap<String, Integer>();

        public String toString() {
            String s = color + ": ";

            for (String key : canCarry.keySet()) {
                s += canCarry.get(key) + " " + key + ", ";
            }

            return s;
        }

        public boolean containsBag(String bagColor) {
            for (String key : canCarry.keySet()) {

                if (key.equals(bagColor))
                    return true;
            }
            return false;
        }

        public int numOfSubBags()
        {
            int sub = 0;

            for (String key : canCarry.keySet()) {

                sub += canCarry.get(key);
            }
            return sub;
        }
    }

}
