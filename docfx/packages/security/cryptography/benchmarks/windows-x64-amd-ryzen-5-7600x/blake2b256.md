| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128B         |      87.20 ns |     1.686 ns |     1.656 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |      96.59 ns |     0.593 ns |     0.555 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     100.45 ns |     0.820 ns |     0.727 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     160.72 ns |     3.160 ns |     3.761 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     500.53 ns |     8.138 ns |     7.612 ns |    1120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 137B         |     167.80 ns |     1.247 ns |     1.167 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     177.36 ns |     0.883 ns |     0.782 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     189.66 ns |     1.723 ns |     1.612 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     297.50 ns |     4.458 ns |     4.170 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |     927.75 ns |    12.324 ns |    11.528 ns |    1136 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1KB          |     626.59 ns |     3.167 ns |     2.962 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     649.17 ns |     4.519 ns |     4.227 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     717.32 ns |     4.035 ns |     3.577 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |   1,141.90 ns |    16.555 ns |    15.485 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,119.64 ns |    54.199 ns |    50.697 ns |    2016 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1025B        |     710.67 ns |     3.351 ns |     3.134 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     732.08 ns |     4.183 ns |     3.913 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     802.51 ns |     4.684 ns |     3.912 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |   1,287.53 ns |    13.290 ns |    11.781 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   3,651.03 ns |    71.800 ns |   102.974 ns |    2024 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 8KB          |   4,988.28 ns |    40.053 ns |    35.506 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,079.36 ns |    28.386 ns |    26.553 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   5,605.08 ns |    29.542 ns |    27.634 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |   9,026.31 ns |    68.175 ns |    56.929 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  23,968.64 ns |   469.455 ns |   439.128 ns |    9184 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128KB        |  79,468.77 ns |   336.729 ns |   298.502 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  81,122.90 ns |   572.712 ns |   535.715 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        |  89,063.90 ns |   394.766 ns |   329.648 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        | 144,746.77 ns | 1,873.272 ns | 1,660.607 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 407,703.38 ns | 6,372.705 ns | 5,961.032 ns |  132078 B |