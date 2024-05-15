use std::fs;

fn main()
{
    let input = fs::read_to_string("day1.input").expect("Unable to read file");

    let mut part1 = 0;
    let mut part2 = 0;
    for (i, c) in input.chars().enumerate() {
        if c == '(' {
            part1 += 1;
        } else if c == ')' {
            part1 -= 1;
        }

        if part1 == -1 && part2 == 0 {
            part2 = i + 1;
        }
    }
    println!("Part 1: {part1}");
    println!("Part 2: {part2}");
} 