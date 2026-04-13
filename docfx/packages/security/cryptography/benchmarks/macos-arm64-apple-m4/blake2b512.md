| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |      91.39 ns |     0.807 ns |     0.673 ns |      91.32 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     103.79 ns |     0.108 ns |     0.101 ns |     103.77 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     128.79 ns |     0.192 ns |     0.179 ns |     128.82 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 128B         |     199.11 ns |     0.143 ns |     0.112 ns |     199.12 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     596.19 ns |    11.900 ns |    15.473 ns |     587.26 ns |    1216 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     169.75 ns |     0.107 ns |     0.100 ns |     169.78 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     194.25 ns |     0.333 ns |     0.311 ns |     194.21 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     234.67 ns |     0.185 ns |     0.173 ns |     234.69 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 137B         |     398.34 ns |     0.470 ns |     0.439 ns |     398.43 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |   1,111.40 ns |     4.998 ns |     4.675 ns |   1,109.85 ns |    1232 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     651.56 ns |     0.517 ns |     0.432 ns |     651.43 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |     745.01 ns |     1.927 ns |     1.802 ns |     745.41 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     873.33 ns |     0.886 ns |     0.740 ns |     873.33 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 1KB          |   1,573.53 ns |     0.292 ns |     0.244 ns |   1,573.47 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,735.41 ns |    20.995 ns |    18.611 ns |   3,739.19 ns |    2112 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     725.45 ns |     2.672 ns |     2.500 ns |     725.66 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |     843.65 ns |     1.082 ns |     0.960 ns |     843.78 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     971.52 ns |     2.347 ns |     2.195 ns |     971.86 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 1025B        |   1,768.82 ns |     0.617 ns |     0.482 ns |   1,768.85 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   4,182.54 ns |    24.432 ns |    22.853 ns |   4,174.79 ns |    2120 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,088.94 ns |    21.311 ns |    19.935 ns |   5,076.06 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |   5,864.66 ns |    22.063 ns |    20.637 ns |   5,863.92 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   6,762.94 ns |    50.009 ns |    39.044 ns |   6,755.56 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 8KB          |  12,549.57 ns |     3.096 ns |     2.585 ns |  12,548.71 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  28,313.70 ns |   159.599 ns |   149.289 ns |  28,315.94 ns |    9280 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  82,507.80 ns |    26.085 ns |    24.400 ns |  82,506.76 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        |  94,272.00 ns |   290.534 ns |   271.766 ns |  94,179.96 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        | 108,466.66 ns |    39.249 ns |    34.793 ns | 108,472.74 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 128KB        | 200,786.27 ns |    23.246 ns |    21.745 ns | 200,784.32 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 479,466.05 ns | 1,505.527 ns | 1,408.271 ns | 479,636.07 ns |  132188 B |