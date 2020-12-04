import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Day4 {

    public static void main(String[] args) {
        List<String> input = AoC.inputRows(4);
        List<Passport> passports = new ArrayList<>();

        //Creating passports
        for (int i = 0; i < input.size(); i++) {
            passports.add(new Passport());

            while (i < input.size() && !input.get(i).equals("")) {

                String[] fields = input.get(i).split(" ");

                for (String field : fields) {
                    String[] info = field.split(":");
                    int index = passports.size() - 1;
                    passports.get(passports.size() - 1).info.put(info[0], info[1]);
                }
                i++;
            }
        }

        int valid = 0, validStrict = 0;
        for (Passport passport : passports) {
            if (passport.isValid())
                valid++;

            if (passport.isValidStrict())
                validStrict++;
        }

        AoC.output(valid);
        AoC.output(validStrict);

    }

    private static class Passport {
        Map<String, String> info = new HashMap<>();

        public boolean isValid() {
            return info.size() > 7 || (info.size() == 7 && !info.containsKey("cid"));
        }

        public boolean isValidStrict() {
            if (isValid()) {
                int byr = Integer.parseInt(info.get("byr"));

                if (byr >= 1920 && byr <= 2002) {
                    int iyr = Integer.parseInt(info.get("iyr"));

                    if (iyr >= 2010 && iyr <= 2020) {
                        int eyr = Integer.parseInt(info.get("eyr"));

                        if (eyr >= 2020 && eyr <= 2030) {
                            int h = 0;
                            boolean hgt = false;
                            if (info.get("hgt").contains("cm")) {
                                h = Integer.parseInt(info.get("hgt").split("cm")[0]);

                                if (h >= 150 && h <= 193)
                                    hgt = true;

                            } else if (info.get("hgt").contains("in")) {
                                h = Integer.parseInt(info.get("hgt").split("in")[0]);

                                if (h >= 59 && h <= 76)
                                    hgt = true;
                            }

                            if (hgt) {
                                String hcl = info.get("hcl");

                                if(hcl.charAt(0) == '#' && hcl.length() == 7)
                                {
                                    String ecl = info.get("ecl");

                                    if(ecl.equals("amb") || ecl.equals("blu") || ecl.equals("brn") || ecl.equals("gry") || ecl.equals("grn") || ecl.equals("hzl") || ecl.equals("oth"))
                                    {
                                        String pid = info.get("pid");

                                        if(pid.length() == 9 && AoC.tryParseInt(pid))
                                        {
                                            return  true;
                                        }
                                    }

                                }
                            }

                        }
                    }
                }
            }

            return false;
        }
    }

}
