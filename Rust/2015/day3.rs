use std::fs;

fn main(){

    let input = fs::read_to_string("day3.input").expect("Unable to read file");

    let mut visited_part1: Vec<(i32, i32)> = vec![(0,0)];
    let mut visited_part2: Vec<(i32, i32)> = vec![(0,0)];

    let mut pos_part1: (i32, i32) = (0,0);
    let mut pos_part2_santa: (i32, i32) = (0,0);
    let mut pos_part2_robot: (i32, i32) = (0,0);
    for (i, c) in input.chars().enumerate() {
        match c {
            '>' => {
                pos_part1.0 += 1;
                pos_part2_robot.0 += (i % 2) as i32;
                pos_part2_santa.0 += ((i+1) % 2) as i32;
            },
            '<' => {
                pos_part1.0 -= 1;
                pos_part2_robot.0 -= (i % 2) as i32;
                pos_part2_santa.0 -= ((i+1) % 2) as i32;
            },
            '^' => {
                pos_part1.1 += 1;
                pos_part2_robot.1 += (i % 2) as i32;
                pos_part2_santa.1 += ((i+1) % 2) as i32;
            },
            'v' => {
                pos_part1.1 -= 1;
                pos_part2_robot.1 -= (i % 2) as i32;
                pos_part2_santa.1 -= ((i+1) % 2) as i32;
            },
            _ => (),
        }

        if !visited_part1.contains(&pos_part1) {
            visited_part1.push(pos_part1);
        }

        if !visited_part2.contains(&pos_part2_santa) {
            visited_part2.push(pos_part2_santa);
        }

        if !visited_part2.contains(&pos_part2_robot) {
            visited_part2.push(pos_part2_robot);
        }
    }
    

    println!("Part 1: {}", visited_part1.len());
    println!("Part 2: {}", visited_part2.len());
}