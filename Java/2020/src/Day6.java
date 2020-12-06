import java.util.List;

public class Day6 {

    public static void main(String[] args) {
        List<String> input = AoC.inputRows(6);

        //Part 1
        int yesCount = 0;

        for (int i = 0; i < input.size(); i++) {
            StringBuilder groupYes = new StringBuilder();
            while (i < input.size() && !input.get(i).equals("")) {
                for (int j = 0; j < input.get(i).length(); j++) {
                    if (groupYes.indexOf(input.get(i).charAt(j) + "") == -1) {
                        groupYes.append(input.get(i).charAt(j));
                    }
                }
                i++;
            }

            yesCount += groupYes.length();
        }

        AoC.output(yesCount);

        //Part 2
        yesCount = 0;

        for (int i = 0; i < input.size(); i++) {

            StringBuilder groupYes = new StringBuilder(input.get(i));
            i++;

            while (i < input.size() && !input.get(i).equals("")) {

                for (int j = 0; j < groupYes.length(); j++) {

                    if(input.get(i).indexOf(groupYes.charAt(j)) == -1)
                    {
                        groupYes.deleteCharAt(j);
                        j--;
                    }
                }

                i++;
            }

            yesCount += groupYes.length();
        }
        AoC.output(yesCount);
    }

}
