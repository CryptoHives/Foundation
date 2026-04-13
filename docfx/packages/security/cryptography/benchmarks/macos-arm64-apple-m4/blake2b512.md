| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |      91.48 ns |     0.191 ns |     0.179 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     101.82 ns |     0.076 ns |     0.067 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     129.09 ns |     0.150 ns |     0.133 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 128B         |     179.22 ns |     0.123 ns |     0.115 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     616.22 ns |     2.484 ns |     2.324 ns |    1216 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     170.21 ns |     0.062 ns |     0.058 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     191.51 ns |     0.169 ns |     0.158 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     234.41 ns |     0.281 ns |     0.263 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 137B         |     362.86 ns |     0.116 ns |     0.103 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |   1,123.08 ns |     4.087 ns |     3.823 ns |    1232 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     654.40 ns |     2.305 ns |     1.925 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |     742.13 ns |     1.204 ns |     1.068 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     891.03 ns |    17.315 ns |    21.264 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 1KB          |   1,462.84 ns |     0.409 ns |     0.341 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,853.15 ns |    24.987 ns |    23.373 ns |    2112 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     735.78 ns |     2.180 ns |     1.933 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |     838.34 ns |     2.775 ns |     2.596 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     978.95 ns |     2.290 ns |     1.788 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 1025B        |   1,652.49 ns |     6.967 ns |     6.517 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   4,366.24 ns |    36.792 ns |    34.416 ns |    2120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,174.06 ns |    24.743 ns |    21.934 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |   5,897.99 ns |    16.958 ns |    14.161 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   6,816.16 ns |    26.455 ns |    23.452 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 8KB          |  11,775.91 ns |    51.955 ns |    48.599 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  29,512.23 ns |   137.092 ns |   121.528 ns |    9280 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  82,640.41 ns |   296.972 ns |   263.258 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        |  94,529.65 ns |   368.296 ns |   344.504 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        | 108,886.45 ns |   522.295 ns |   488.555 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 128KB        | 188,210.73 ns |   578.133 ns |   540.786 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 477,473.47 ns | 1,482.936 ns | 1,238.319 ns |  132188 B |