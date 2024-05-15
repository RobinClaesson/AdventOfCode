use std::fs;

fn main()
{
    let input = fs::read_to_string("day2.input").expect("Unable to read file");

    let mut part1 = 0;
    let mut part2 = 0;

    for present in input.lines() {
        let mut sides: Vec<i32> = present.split("x")
                                    .map(|x| x.parse::<i32>().unwrap())
                                    .collect();
        sides.sort();

        part1 += 2 * sides[0] * sides[1] + 2 * sides[1] * sides[2] + 2 * sides[2] * sides[0];
        part1 += sides[0] * sides[1];

        part2 += 2 * sides[0] + 2 * sides[1];
        part2 += sides[0] * sides[1] * sides[2];
    }

    println!("Part1: {}", part1);
    println!("Part2: {}", part2);
} 