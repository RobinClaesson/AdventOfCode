fn main() {
    let input = "ckczppom";

    {
        let mut part1 = 0;
        let mut first_five = "".to_string();
        while first_five != "00000" {
            part1 += 1;
            let digest = md5::compute(format!("{}{}", input, part1));
            first_five = format!("{:x}", digest)[0..5].to_string();
        }

        println!("Part 1: {}", part1);
    }

    {
        let mut part2 = 0;
        let mut first_six = "".to_string();
        while first_six != "000000" {
            part2 += 1;
            let digest = md5::compute(format!("{}{}", input, part2));
            first_six = format!("{:x}", digest)[0..6].to_string();
        }

        println!("Part 2: {}", part2);
    }
}
