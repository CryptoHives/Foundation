| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 128B         |      99.60 ns |     0.622 ns |     0.582 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 128B         |     119.96 ns |     2.218 ns |     2.179 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 128B         |     370.40 ns |     2.608 ns |     2.312 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 137B         |     189.67 ns |     0.822 ns |     0.729 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 137B         |     210.14 ns |     1.379 ns |     1.290 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 137B         |     724.00 ns |     4.439 ns |     3.935 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 1KB          |     715.98 ns |     4.807 ns |     4.261 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 1KB          |     796.95 ns |     7.405 ns |     6.565 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 1KB          |   2,849.76 ns |    14.322 ns |    12.696 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 1025B        |     807.91 ns |     3.485 ns |     3.089 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 1025B        |     900.86 ns |    12.477 ns |    11.671 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 1025B        |   3,196.15 ns |    20.950 ns |    19.597 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 8KB          |   5,614.11 ns |    33.398 ns |    31.240 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 8KB          |   6,331.31 ns |    84.972 ns |    75.326 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 8KB          |  22,838.37 ns |   134.214 ns |   125.544 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2         | 128KB        | 101,277.89 ns | 1,017.042 ns |   901.581 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 128KB        | 105,416.37 ns | 1,552.811 ns | 1,452.501 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 128KB        | 368,544.80 ns | 3,821.455 ns | 3,574.592 ns |         - |