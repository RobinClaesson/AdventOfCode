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

    public static ArrayList<Integer> inputRows_Int(int day){
        File file = new File("Input" + day + ".txt");
        Scanner reader = getReader(day);

        ArrayList<Integer> input = new ArrayList<>();

        while (reader.hasNextLine()) {
            input.add(reader.nextInt());

        }

        return input;

    }

    private static int part = 1;

    public static void Output(String result) {
        System.out.println("Answer part " + part + ": " + result);

        part++;
    }

    public static void Output(int result) {
        Output("" + result);
    }
}
