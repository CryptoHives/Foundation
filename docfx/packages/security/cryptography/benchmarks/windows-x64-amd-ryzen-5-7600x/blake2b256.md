| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128B         |      88.18 ns |     1.416 ns |     1.324 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     101.99 ns |     0.942 ns |     0.881 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |     104.51 ns |     1.412 ns |     1.321 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     384.08 ns |     7.521 ns |     7.035 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     512.15 ns |    10.040 ns |    16.496 ns |    1120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 137B         |     167.25 ns |     1.181 ns |     1.047 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     187.53 ns |     1.546 ns |     1.371 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     188.58 ns |     1.292 ns |     1.208 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     757.64 ns |    11.759 ns |    10.424 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |     945.74 ns |    15.894 ns |    14.868 ns |    1136 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1KB          |     629.62 ns |     4.436 ns |     4.149 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     663.24 ns |     4.686 ns |     4.383 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     716.56 ns |     2.368 ns |     1.978 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |   2,994.58 ns |    51.377 ns |    45.544 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,159.35 ns |    52.996 ns |    49.572 ns |    2016 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1025B        |     713.13 ns |     3.487 ns |     3.262 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     744.82 ns |     3.327 ns |     3.112 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     802.09 ns |     2.651 ns |     2.350 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |   3,349.39 ns |    46.711 ns |    43.694 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   3,579.16 ns |    39.210 ns |    34.759 ns |    2024 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 8KB          |   5,005.39 ns |    37.476 ns |    35.055 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,117.18 ns |    35.576 ns |    31.537 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   5,592.75 ns |    33.215 ns |    31.069 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |  23,767.84 ns |   436.453 ns |   408.259 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  24,247.81 ns |   124.810 ns |   110.641 ns |    9184 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128KB        |  79,760.62 ns |   383.722 ns |   340.159 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  81,338.34 ns |   488.100 ns |   432.687 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        |  89,258.04 ns |   260.648 ns |   231.058 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        | 379,956.29 ns | 6,970.219 ns | 6,519.947 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 415,607.24 ns | 8,302.629 ns | 8,154.292 ns |  132078 B |