import java.util.List;

public class Day2 {

    public static void main(String[] args) {

        List<String[]> input = AoC.inputRowsSplit(2, " ");

        int valid1 = 0, valid2 = 0;

        for (String[] row : input) {
            String[] lowHigh = row[0].split("-");
//            System.out.println("Low:" + lowHigh[0] + "|High:" + lowHigh[1]);

            int lowest = Integer.parseInt(lowHigh[0]);
            int highest = Integer.parseInt(lowHigh[1]);

            char lookFor = row[1].charAt(0);
            char[] password = row[2].toCharArray();

            //Part1
            int amount = 0;

            for (char c : password) {
                if (c == lookFor)
                    amount++;
            }

            if (amount >= lowest && amount <= highest)
                valid1++;


            //Part 2
            if ((password[lowest - 1] == lookFor && password[highest - 1] != lookFor) || (password[lowest - 1] != lookFor && password[highest - 1] == lookFor))
                valid2++;

        }


        AoC.Output(valid1);
        AoC.Output(valid2);

    }

}
