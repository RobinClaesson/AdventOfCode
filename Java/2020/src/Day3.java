import java.util.List;

public class Day3 {

    public static void main(String[] args) {
        List<String> input = AoC.inputRows(3);

        //Part 1
        AoC.output(treesHit(3, 1, input));

        long part2 = treesHit(1, 1, input);
        part2 *= treesHit(3, 1, input);
        part2 *= treesHit(5, 1, input);
        part2 *= treesHit(7, 1, input);
        part2 *= treesHit(1, 2, input);

        AoC.output(part2);
    }

    public static int treesHit(int xSlope, int ySlope, List<String> input) {
        int x = 0, y = 0, hitTrees = 0;
        while (y < input.size()) {
            //System.out.println("Pos: " + x + "," + y);

            //Emulates the patern going on forever
            if (x >= input.get(y).length())
                x -= input.get(y).length();

            if (input.get(y).charAt(x) == '#')
                hitTrees++;

            x += xSlope;
            y += ySlope;
        }

        return hitTrees;

    }


}
