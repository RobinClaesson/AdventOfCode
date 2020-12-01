import java.util.ArrayList;
import java.util.List;

public class Day1 {

    public static void main(String[] args){

        List<Integer> input = AoC.inputRows_Int(1);

        part1(input);
        part2(input);

    }

    private static void part1(List<Integer> input) {
        for (int i = 0; i < input.size(); i++) {
            for (int j = 0; j < input.size(); j++) {
                int sum = input.get(i) + input.get(j);

                if (sum == 2020) {
                    AoC.Output(input.get(i) * input.get(j));
                    return;
                }
            }
        }
    }

    private static void part2(List<Integer> input) {
        for (int i = 0; i < input.size(); i++) {
            for (int j = 0; j < input.size(); j++) {
                for (int k = 0; k < input.size(); k++) {
                    int sum = input.get(i) + input.get(j) + input.get(k);

                    if (sum == 2020) {
                        AoC.Output(input.get(i) * input.get(j) * input.get(k));
                        return;
                    }
                }
            }
        }
    }

}
