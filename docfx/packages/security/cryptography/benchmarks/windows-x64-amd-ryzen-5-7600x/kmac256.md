| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-256 · Managed      | 128B         |     744.6 ns |     2.74 ns |     2.29 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 128B         |   1,032.4 ns |     7.63 ns |     7.14 ns |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 128B         |   1,967.1 ns |    13.38 ns |    11.86 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 137B         |     921.4 ns |     5.38 ns |     5.03 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 137B         |   1,273.0 ns |     9.25 ns |     8.20 ns |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 137B         |   2,257.6 ns |    14.31 ns |    12.69 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 1KB          |   2,081.3 ns |     8.96 ns |     7.00 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 1KB          |   2,752.8 ns |    16.57 ns |    15.50 ns |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 1KB          |   4,130.8 ns |    38.70 ns |    34.31 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 1025B        |   2,091.3 ns |    24.27 ns |    22.70 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 1025B        |   2,750.9 ns |    23.19 ns |    20.56 ns |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 1025B        |   4,119.0 ns |    21.04 ns |    18.65 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 8KB          |  12,628.6 ns |   114.86 ns |    95.92 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 8KB          |  15,873.2 ns |   122.25 ns |   114.35 ns |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 8KB          |  20,438.9 ns |   102.14 ns |    90.55 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 128KB        | 192,457.3 ns | 1,259.64 ns | 1,178.27 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 128KB        | 267,522.4 ns | 2,476.28 ns | 2,316.32 ns |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 128KB        | 296,191.4 ns | 1,828.71 ns | 1,621.10 ns |     256 B |