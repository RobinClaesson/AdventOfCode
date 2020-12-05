import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Day5 {

    public static void main(String[] args) {
        List<String> input = AoC.inputRows(5);

        List<Integer> seats = new ArrayList<>();
        int highID = -1;
        //Calculates seatIDs and part1
        for (String seat : input) {

            String rowInfo = seat.substring(0, 7);
            int row = BinaryValueFromString(rowInfo, 'B');

            String columnInfo = seat.substring(7);
            int column = BinaryValueFromString(columnInfo, 'R');

            int seatID = 8 * row + column;

            if (seatID > highID)
                highID = seatID;

            seats.add(seatID);
        }

        AoC.output(highID);

        //Part 2
        Collections.sort(seats);
        int first = seats.get(0);

        for (int i = 0; i < seats.size(); i++) {
            if (seats.get(i) != first + i) {
                AoC.output(i + first);
                break;
            }
        }

    }

    private static int BinaryValueFromString(String s, char one) {
        int value = 0;
        for (int i = 0; i < s.length(); i++) {

            if (s.charAt(s.length() - 1 - i) == one) {
                value += Math.pow(2, i);
            }
        }

        return value;
    }

}
