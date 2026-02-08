| Description                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · ComputeHash · Managed      | 128B         |     698.5 ns |     4.38 ns |     4.09 ns |     176 B |
| ComputeMac · ComputeHash · OS Native    | 128B         |     968.6 ns |     5.18 ns |     4.60 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 128B         |   1,312.6 ns |     6.21 ns |     5.81 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 137B         |     945.3 ns |     5.78 ns |     5.40 ns |     176 B |
| ComputeMac · ComputeHash · OS Native    | 137B         |   1,210.4 ns |     6.34 ns |     5.62 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 137B         |   1,594.7 ns |     6.62 ns |     6.19 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 1KB          |   2,101.9 ns |    11.14 ns |    10.42 ns |     176 B |
| ComputeMac · ComputeHash · OS Native    | 1KB          |   2,609.6 ns |    17.29 ns |    16.17 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 1KB          |   3,437.2 ns |     8.42 ns |     7.03 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 1025B        |   2,097.0 ns |    13.26 ns |    12.40 ns |     176 B |
| ComputeMac · ComputeHash · OS Native    | 1025B        |   2,636.3 ns |    38.34 ns |    33.98 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 1025B        |   3,426.9 ns |     7.01 ns |     5.85 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 8KB          |  12,655.2 ns |   136.04 ns |   127.25 ns |     176 B |
| ComputeMac · ComputeHash · OS Native    | 8KB          |  15,101.3 ns |   107.00 ns |   100.09 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 8KB          |  19,705.6 ns |   244.26 ns |   228.48 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 128KB        | 190,237.2 ns |   994.18 ns |   929.96 ns |     176 B |
| ComputeMac · ComputeHash · OS Native    | 128KB        | 226,940.5 ns |   683.66 ns |   639.49 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 128KB        | 294,631.7 ns | 1,909.41 ns | 1,786.07 ns |     160 B |