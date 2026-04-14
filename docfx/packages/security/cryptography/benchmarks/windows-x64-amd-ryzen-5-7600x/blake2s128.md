| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128B         |     156.4 ns |     1.12 ns |     1.05 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128B         |     157.4 ns |     2.13 ns |     1.99 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128B         |     159.8 ns |     1.09 ns |     1.02 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128B         |     161.9 ns |     2.91 ns |     2.72 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 137B         |     227.3 ns |     0.83 ns |     0.77 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 137B         |     235.5 ns |     1.22 ns |     1.02 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 137B         |     237.4 ns |     3.30 ns |     2.75 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 137B         |     240.2 ns |     2.49 ns |     2.08 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1KB          |   1,142.0 ns |     7.61 ns |     7.12 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1KB          |   1,211.9 ns |    14.78 ns |    13.82 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1KB          |   1,215.4 ns |     5.48 ns |     5.12 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1KB          |   1,232.5 ns |    10.24 ns |     9.58 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1025B        |   1,222.9 ns |    10.26 ns |     9.09 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1025B        |   1,289.4 ns |    10.02 ns |     9.37 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1025B        |   1,299.1 ns |     8.31 ns |     7.37 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1025B        |   1,307.0 ns |     7.58 ns |     6.72 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 8KB          |   9,029.6 ns |    54.63 ns |    48.43 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 8KB          |   9,575.4 ns |    87.52 ns |    81.87 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 8KB          |   9,663.9 ns |    38.08 ns |    33.75 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 8KB          |   9,783.9 ns |   124.71 ns |   116.66 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128KB        | 145,986.2 ns | 2,369.96 ns | 2,216.86 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128KB        | 153,683.3 ns | 1,147.98 ns | 1,017.65 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128KB        | 154,482.8 ns |   803.94 ns |   752.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128KB        | 155,453.0 ns |   890.28 ns |   832.77 ns |         - |