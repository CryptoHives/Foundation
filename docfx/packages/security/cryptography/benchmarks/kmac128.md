| Description                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · ComputeHash · Managed      | 128B         |     696.0 ns |     2.99 ns |     2.80 ns |     112 B |
| ComputeMac · ComputeHash · OS Native    | 128B         |     970.0 ns |     3.56 ns |     3.33 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 128B         |   1,324.0 ns |     5.05 ns |     4.48 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 137B         |     689.3 ns |     3.65 ns |     3.42 ns |     112 B |
| ComputeMac · ComputeHash · OS Native    | 137B         |     979.4 ns |     3.99 ns |     3.33 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 137B         |   1,314.4 ns |     6.45 ns |     5.72 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 1KB          |   1,929.2 ns |    12.47 ns |    11.66 ns |     112 B |
| ComputeMac · ComputeHash · OS Native    | 1KB          |   2,379.8 ns |     8.19 ns |     7.26 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 1KB          |   3,161.1 ns |    13.01 ns |    12.17 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 1025B        |   1,923.6 ns |     7.77 ns |     6.88 ns |     112 B |
| ComputeMac · ComputeHash · OS Native    | 1025B        |   2,406.3 ns |    21.05 ns |    19.69 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 1025B        |   3,159.6 ns |     8.48 ns |     7.08 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 8KB          |  10,270.2 ns |    79.64 ns |    74.50 ns |     112 B |
| ComputeMac · ComputeHash · OS Native    | 8KB          |  12,412.5 ns |   100.34 ns |    93.86 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 8KB          |  15,958.4 ns |    37.83 ns |    29.54 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · ComputeHash · Managed      | 128KB        | 156,042.4 ns |   842.02 ns |   703.13 ns |     112 B |
| ComputeMac · ComputeHash · OS Native    | 128KB        | 186,234.2 ns | 1,282.79 ns | 1,199.92 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 128KB        | 239,234.5 ns | 1,151.46 ns | 1,077.08 ns |     160 B |