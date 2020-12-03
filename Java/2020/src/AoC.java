import java.io.File;
import java.net.URL;
import java.util.ArrayList;
import java.util.Scanner;

public class AoC {

    private static Scanner getReader(int day) {
        URL path = AoC.class.getResource("Input" + day + ".txt");
        File file = new File(path.getFile());

        try {

            return new Scanner(file);
        } catch (Exception e) {

            return null;
        }
    }

    public static String input(int day) {

        StringBuilder s = new StringBuilder();

        Scanner reader = getReader(day);

        while (reader.hasNextLine())
            s.append(reader.nextLine());

        return s.toString();

    }

    public static ArrayList<String> inputRows(int day) {
        Scanner reader = getReader(day);

        ArrayList<String> input = new ArrayList<>();

        while (reader.hasNextLine())
            input.add(reader.nextLine());

        return input;

    }

    public static ArrayList<Integer> inputRows_Int(int day) {
        Scanner reader = getReader(day);

        ArrayList<Integer> input = new ArrayList<>();

        while (reader.hasNextLine()) {
            input.add(reader.nextInt());

        }

        return input;

    }

    public static ArrayList<String[]> inputRowsSplit(int day, String splitAt) {
        Scanner reader = getReader(day);

        ArrayList<String[]> input = new ArrayList<>();

        while (reader.hasNextLine())
            input.add(reader.nextLine().split(splitAt));

        return input;
    }


    private static int outputs = 1;

    public static void output(String result) {
        System.out.println("Answer part " + outputs + ": " + result);

        outputs++;
    }

    public static void output(int result) {
        output("" + result);
    }

    public static void output(long result) {
        output(result + "");
    }
}
