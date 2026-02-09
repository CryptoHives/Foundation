| Description                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · TryComputeHash · Managed   | 128B         |     684.1 ns |     2.77 ns |     2.17 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 128B         |     979.2 ns |     7.54 ns |     7.06 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 128B         |   1,317.1 ns |     7.89 ns |     7.38 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · TryComputeHash · Managed   | 137B         |     681.5 ns |     2.98 ns |     2.64 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 137B         |     999.1 ns |     6.96 ns |     6.17 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 137B         |   1,313.4 ns |     6.31 ns |     5.60 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · TryComputeHash · Managed   | 1KB          |   1,913.4 ns |    12.64 ns |    11.21 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 1KB          |   2,387.7 ns |     9.57 ns |     7.99 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 1KB          |   3,144.8 ns |    17.82 ns |    16.67 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · TryComputeHash · Managed   | 1025B        |   1,917.9 ns |    15.19 ns |    14.21 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 1025B        |   2,404.8 ns |    11.15 ns |    10.43 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 1025B        |   3,141.0 ns |    12.15 ns |    11.37 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · TryComputeHash · Managed   | 8KB          |  10,210.1 ns |    62.72 ns |    58.66 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 8KB          |  12,302.0 ns |    59.27 ns |    55.44 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 8KB          |  16,053.3 ns |    86.60 ns |    81.00 ns |     160 B |
|                                         |              |              |             |             |           |
| ComputeMac · TryComputeHash · Managed   | 128KB        | 155,508.1 ns |   692.57 ns |   647.83 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 128KB        | 185,262.8 ns | 1,187.57 ns | 1,110.86 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 128KB        | 239,918.3 ns |   755.69 ns |   706.87 ns |     160 B |