| Description                             | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| ComputeMac · TryComputeHash · Managed   | 128B         |     670.2 ns |     3.73 ns |   3.49 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 128B         |     981.9 ns |     5.51 ns |   4.88 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 128B         |   1,307.9 ns |     5.31 ns |   4.71 ns |     160 B |
|                                         |              |              |             |           |           |
| ComputeMac · TryComputeHash · Managed   | 137B         |     910.6 ns |     4.05 ns |   3.79 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 137B         |   1,225.4 ns |     5.72 ns |   5.07 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 137B         |   1,599.8 ns |     5.55 ns |   4.92 ns |     160 B |
|                                         |              |              |             |           |           |
| ComputeMac · TryComputeHash · Managed   | 1KB          |   2,056.8 ns |     8.67 ns |   7.69 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 1KB          |   2,613.5 ns |    14.35 ns |  13.42 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 1KB          |   3,421.4 ns |     6.58 ns |   5.83 ns |     160 B |
|                                         |              |              |             |           |           |
| ComputeMac · TryComputeHash · Managed   | 1025B        |   2,060.7 ns |    10.94 ns |   9.14 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 1025B        |   2,671.6 ns |    13.54 ns |  12.66 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 1025B        |   3,417.1 ns |    12.41 ns |  11.61 ns |     160 B |
|                                         |              |              |             |           |           |
| ComputeMac · TryComputeHash · Managed   | 8KB          |  12,493.1 ns |    55.66 ns |  52.06 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 8KB          |  15,070.9 ns |    59.46 ns |  55.62 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 8KB          |  19,467.7 ns |    55.94 ns |  46.71 ns |     160 B |
|                                         |              |              |             |           |           |
| ComputeMac · TryComputeHash · Managed   | 128KB        | 189,517.1 ns |   467.77 ns | 390.61 ns |         - |
| ComputeMac · ComputeHash · OS Native    | 128KB        | 226,397.1 ns | 1,119.12 ns | 992.07 ns |      32 B |
| ComputeMac · ComputeHash · BouncyCastle | 128KB        | 292,863.5 ns |   881.67 ns | 781.57 ns |     160 B |