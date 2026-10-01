| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |         92.86 ns |       0.355 ns |       0.332 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |         96.75 ns |       0.287 ns |       0.255 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        123.58 ns |       0.313 ns |       0.293 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 4B           |        171.62 ns |       1.001 ns |       0.936 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |        731.66 ns |       1.272 ns |       1.190 ns |     1000 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |         92.14 ns |       0.213 ns |       0.189 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |         96.30 ns |       0.265 ns |       0.248 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        124.66 ns |       0.408 ns |       0.382 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 64B          |        174.65 ns |       1.145 ns |       0.956 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |        708.12 ns |       1.231 ns |       1.091 ns |     1056 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |         92.46 ns |       0.217 ns |       0.203 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |         96.90 ns |       0.276 ns |       0.258 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        124.65 ns |       0.334 ns |       0.296 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 65B          |        175.84 ns |       0.515 ns |       0.456 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |        707.98 ns |       1.477 ns |       1.381 ns |     1064 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |         92.25 ns |       0.267 ns |       0.237 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |         94.20 ns |       0.266 ns |       0.235 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        124.97 ns |       0.435 ns |       0.407 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |        175.99 ns |       0.621 ns |       0.550 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        682.05 ns |       1.684 ns |       1.575 ns |     1120 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        172.24 ns |       0.528 ns |       0.494 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        190.88 ns |       0.383 ns |       0.358 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        232.37 ns |       0.494 ns |       0.462 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 129B         |        355.01 ns |       1.050 ns |       0.982 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,287.54 ns |       2.448 ns |       2.170 ns |     1128 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        664.33 ns |       1.541 ns |       1.366 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |        754.55 ns |       2.208 ns |       1.958 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        884.46 ns |       2.654 ns |       2.352 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |      1,432.82 ns |       3.289 ns |       2.915 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      4,465.44 ns |      11.852 ns |      11.087 ns |     2016 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |        754.60 ns |       1.200 ns |       1.122 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |        857.19 ns |       2.318 ns |       2.054 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |        990.98 ns |       2.576 ns |       2.409 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |      1,611.66 ns |       3.753 ns |       3.327 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      5,096.38 ns |      10.941 ns |       9.699 ns |     2024 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      5,185.48 ns |      18.876 ns |      17.656 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |      6,012.70 ns |      11.453 ns |      10.714 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      6,922.62 ns |      16.691 ns |      14.796 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |     11,486.81 ns |      28.863 ns |      26.999 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     34,167.57 ns |      88.818 ns |      83.081 ns |     9184 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     41,416.78 ns |     150.063 ns |     140.369 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |     47,456.59 ns |     152.503 ns |     142.652 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     54,445.58 ns |     220.981 ns |     206.706 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 64KB         |     83,571.81 ns |     390.184 ns |     345.888 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    265,543.84 ns |   1,659.039 ns |   1,470.695 ns |    66528 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |     82,810.40 ns |     223.578 ns |     209.135 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |     94,386.28 ns |     403.383 ns |     357.589 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |    109,037.56 ns |     392.005 ns |     347.502 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        |    166,558.59 ns |     553.491 ns |     517.736 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    536,973.26 ns |   2,520.135 ns |   2,357.335 ns |   132092 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    630,625.44 ns |   1,157.622 ns |   1,082.840 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |    718,337.13 ns |   2,662.918 ns |   2,490.895 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    832,839.76 ns |   3,104.797 ns |   2,904.229 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1MB          |  1,270,654.37 ns |   4,692.363 ns |   4,389.239 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  3,952,641.12 ns |  32,396.614 ns |  30,303.812 ns |  1002599 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  6,315,064.22 ns |  30,525.164 ns |  27,059.763 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         |  7,179,737.46 ns |  26,331.275 ns |  23,341.990 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  8,320,191.79 ns |  30,470.911 ns |  27,011.669 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 10MB         | 12,727,663.19 ns |  45,946.769 ns |  42,978.637 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 40,349,150.84 ns | 137,131.351 ns | 128,272.751 ns | 10001193 B |