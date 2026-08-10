| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-128 · Managed      | 128B         |     674.0 ns |     4.61 ns |     4.31 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 128B         |   1,016.5 ns |     8.88 ns |     8.31 ns |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 128B         |   1,987.5 ns |     9.01 ns |     7.98 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 137B         |     669.3 ns |     4.38 ns |     3.88 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 137B         |   1,021.1 ns |    14.71 ns |    13.04 ns |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 137B         |   1,993.8 ns |    15.45 ns |    14.45 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 1KB          |   1,915.6 ns |    12.55 ns |    10.48 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 1KB          |   2,504.1 ns |    19.01 ns |    17.78 ns |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 1KB          |   3,832.6 ns |    19.58 ns |    18.31 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 1025B        |   1,917.0 ns |    15.84 ns |    14.82 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 1025B        |   2,503.3 ns |    24.32 ns |    22.75 ns |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 1025B        |   3,833.7 ns |    18.55 ns |    15.49 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 8KB          |  10,303.1 ns |    79.25 ns |    74.13 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 8KB          |  13,069.1 ns |    93.77 ns |    83.13 ns |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 8KB          |  16,867.4 ns |   107.45 ns |   100.51 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-128 · Managed      | 128KB        | 157,122.3 ns | 1,681.94 ns | 1,404.49 ns |         - |
| TryComputeHash · KMAC-128 · OS Native    | 128KB        | 224,866.0 ns | 1,087.94 ns |   964.43 ns |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle | 128KB        | 242,471.5 ns | 1,023.51 ns |   907.32 ns |     256 B |