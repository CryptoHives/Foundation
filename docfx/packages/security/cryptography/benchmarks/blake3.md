| Description                            | TestDataSize | Mean            | Error        | StdDev       | Allocated |
|--------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE3 · Native       | 128B         |        98.39 ns |     0.391 ns |     0.327 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128B         |       355.66 ns |     1.115 ns |     1.043 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128B         |       544.87 ns |     1.636 ns |     1.450 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128B         |     1,272.50 ns |     4.196 ns |     3.925 ns |         - |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 137B         |       151.20 ns |     0.426 ns |     0.356 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 137B         |       419.23 ns |     1.152 ns |     1.077 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 137B         |       805.77 ns |     1.861 ns |     1.649 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 137B         |     1,891.36 ns |     4.859 ns |     4.545 ns |         - |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 1KB          |       746.48 ns |     2.645 ns |     2.208 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1KB          |     1,274.75 ns |     3.081 ns |     2.731 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1KB          |     4,196.70 ns |    20.365 ns |    19.050 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1KB          |     9,424.47 ns |    16.199 ns |    15.152 ns |         - |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 1025B        |       849.97 ns |     2.728 ns |     2.552 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1025B        |     1,418.83 ns |     2.097 ns |     1.858 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1025B        |     4,722.27 ns |    12.111 ns |    11.329 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1025B        |    10,793.71 ns |    47.056 ns |    44.017 ns |      56 B |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 8KB          |     1,166.04 ns |     3.693 ns |     3.273 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 8KB          |    10,323.21 ns |    18.485 ns |    16.387 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 8KB          |    35,371.36 ns |    99.216 ns |    87.952 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 8KB          |    79,889.68 ns |   253.869 ns |   237.469 ns |     392 B |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 128KB        |    14,289.54 ns |    29.832 ns |    26.446 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128KB        |   168,702.79 ns |   337.102 ns |   298.832 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128KB        |   569,295.17 ns | 3,119.345 ns | 2,917.838 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128KB        | 1,300,849.00 ns | 3,578.093 ns | 3,346.951 ns |    7112 B |