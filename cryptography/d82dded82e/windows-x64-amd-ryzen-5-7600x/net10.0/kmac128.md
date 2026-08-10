| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-128 · Managed      | 128B         |     663.0 ns |     4.79 ns |     4.48 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 128B         |   1,002.6 ns |     4.56 ns |     4.05 ns |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 128B         |   1,968.0 ns |    11.58 ns |    10.27 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 137B         |     658.5 ns |     3.18 ns |     2.97 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 137B         |   1,021.5 ns |     9.15 ns |     8.11 ns |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 137B         |   1,964.5 ns |     7.34 ns |     6.51 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 1KB          |   1,890.0 ns |     6.21 ns |     5.50 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 1KB          |   2,480.8 ns |     9.25 ns |     8.66 ns |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 1KB          |   3,778.8 ns |    22.56 ns |    21.10 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 1025B        |   1,890.2 ns |     7.46 ns |     6.98 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 1025B        |   2,491.5 ns |    14.28 ns |    13.36 ns |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 1025B        |   3,799.9 ns |    21.49 ns |    20.10 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 8KB          |  10,151.4 ns |    46.49 ns |    43.49 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 8KB          |  12,855.6 ns |    41.59 ns |    34.73 ns |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 8KB          |  16,693.3 ns |    84.67 ns |    75.06 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 128KB        | 154,955.0 ns |   883.94 ns |   783.59 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 128KB        | 223,594.4 ns | 1,454.16 ns | 1,360.22 ns |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 128KB        | 240,585.1 ns | 1,056.01 ns |   987.80 ns |     256 B |