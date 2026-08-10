| Description                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE3 · Native        | 128B         |      99.74 ns |     0.154 ns |     0.144 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 128B         |     240.25 ns |     0.670 ns |     0.594 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 128B         |     505.29 ns |     2.636 ns |     2.466 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 128B         |     714.68 ns |     2.053 ns |     1.920 ns |         - |
|                                         |              |               |              |              |           |
| TryComputeHash · BLAKE3 · Native        | 137B         |     145.58 ns |     0.719 ns |     0.672 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 137B         |     362.87 ns |     0.268 ns |     0.238 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 137B         |     747.42 ns |     4.896 ns |     4.340 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 137B         |   1,056.22 ns |     3.525 ns |     3.298 ns |         - |
|                                         |              |               |              |              |           |
| TryComputeHash · BLAKE3 · Native        | 1KB          |     755.99 ns |     2.791 ns |     2.611 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 1KB          |   1,932.62 ns |     1.334 ns |     1.114 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 1KB          |   3,831.31 ns |    17.674 ns |    16.532 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 1KB          |   5,270.17 ns |    15.810 ns |    14.789 ns |         - |
|                                         |              |               |              |              |           |
| TryComputeHash · BLAKE3 · Native        | 1025B        |     863.61 ns |     3.061 ns |     2.863 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 1025B        |   2,174.50 ns |     2.289 ns |     1.911 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 1025B        |   4,488.02 ns |    30.551 ns |    28.578 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 1025B        |   6,000.20 ns |    17.223 ns |    16.110 ns |      56 B |
|                                         |              |               |              |              |           |
| TryComputeHash · BLAKE3 · Native        | 8KB          |   3,248.31 ns |     8.311 ns |     7.368 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 8KB          |  17,042.59 ns |    18.431 ns |    16.339 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 8KB          |  33,495.59 ns |   171.921 ns |   160.815 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 8KB          |  44,356.23 ns |   151.736 ns |   134.510 ns |     392 B |
|                                         |              |               |              |              |           |
| TryComputeHash · BLAKE3 · Native        | 128KB        |  51,209.95 ns |   144.621 ns |   120.765 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 128KB        | 277,998.47 ns |   261.820 ns |   232.097 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 128KB        | 539,463.51 ns | 3,637.687 ns | 3,402.694 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 128KB        | 710,528.83 ns | 1,396.229 ns | 1,237.721 ns |    7112 B |