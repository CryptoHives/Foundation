| Description                            | TestDataSize | Mean            | Error        | StdDev       | Allocated |
|--------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE3 · Native       | 128B         |        98.50 ns |     0.291 ns |     0.258 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128B         |       141.13 ns |     0.900 ns |     0.797 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128B         |       542.16 ns |     5.224 ns |     4.631 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128B         |     1,269.16 ns |     7.155 ns |     5.975 ns |         - |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 137B         |       150.86 ns |     0.578 ns |     0.541 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 137B         |       222.24 ns |     0.650 ns |     0.608 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 137B         |       805.45 ns |     4.625 ns |     4.326 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 137B         |     1,906.03 ns |     8.576 ns |     8.022 ns |         - |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 1KB          |       746.07 ns |     1.921 ns |     1.797 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1KB          |     1,076.07 ns |     5.175 ns |     4.840 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1KB          |     4,190.81 ns |    21.365 ns |    17.841 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1KB          |     9,446.48 ns |    50.202 ns |    46.959 ns |         - |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 1025B        |       851.46 ns |     1.567 ns |     1.389 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1025B        |     1,234.30 ns |     4.919 ns |     4.601 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1025B        |     4,749.23 ns |    29.655 ns |    27.739 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1025B        |    10,651.64 ns |    59.991 ns |    50.095 ns |      56 B |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 8KB          |     1,167.09 ns |     2.543 ns |     2.378 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 8KB          |    10,080.22 ns |   120.496 ns |   112.712 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 8KB          |    35,575.72 ns |   247.074 ns |   231.113 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 8KB          |    79,560.66 ns |   408.414 ns |   382.031 ns |     392 B |
|                                        |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Native       | 128KB        |    14,301.89 ns |    28.178 ns |    23.530 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128KB        |   165,547.99 ns |   368.609 ns |   344.797 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128KB        |   567,652.31 ns | 4,536.853 ns | 3,788.478 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128KB        | 1,310,452.36 ns | 8,633.627 ns | 8,075.900 ns |    7112 B |