| Description                                       | TestDataSize | Mean            | Error         | StdDev        | Median          | Code Size | Allocated  |
|-------------------------------------------------- |------------- |----------------:|--------------:|--------------:|----------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 4B           |        140.9 ns |       0.49 ns |       0.93 ns |        141.0 ns |   6,270 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |        153.7 ns |       2.37 ns |       4.50 ns |        152.9 ns |   5,897 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        171.8 ns |       1.18 ns |       2.22 ns |        173.0 ns |   6,975 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |        215.2 ns |       0.76 ns |       1.46 ns |        214.8 ns |   8,229 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |      1,279.0 ns |       1.67 ns |       3.17 ns |      1,278.7 ns |   8,756 B |     1096 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64B          |        140.2 ns |       1.35 ns |       2.57 ns |        140.5 ns |   6,253 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |        155.0 ns |       3.94 ns |       7.49 ns |        151.3 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        172.6 ns |       0.56 ns |       1.06 ns |        172.3 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |        213.5 ns |       0.43 ns |       0.82 ns |        213.5 ns |   8,219 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |      1,145.8 ns |       3.93 ns |       7.28 ns |      1,144.2 ns |   8,745 B |     1152 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 65B          |        151.9 ns |       1.97 ns |       3.74 ns |        152.2 ns |   6,274 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |        155.9 ns |       0.33 ns |       0.64 ns |        156.0 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        171.1 ns |       0.65 ns |       1.23 ns |        171.4 ns |   6,975 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |        214.3 ns |       0.29 ns |       0.54 ns |        214.4 ns |   8,253 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |      1,146.7 ns |       2.04 ns |       3.78 ns |      1,147.2 ns |   8,734 B |     1160 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |        143.1 ns |       2.79 ns |       5.24 ns |        144.6 ns |   6,245 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |        148.0 ns |       0.94 ns |       1.79 ns |        148.1 ns |   5,916 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        171.1 ns |       0.56 ns |       1.07 ns |        171.4 ns |   6,973 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |        207.8 ns |       0.32 ns |       0.61 ns |        207.7 ns |   8,218 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |      1,022.6 ns |       1.07 ns |       1.95 ns |      1,022.8 ns |   8,726 B |     1216 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        268.5 ns |       2.28 ns |       4.33 ns |        266.8 ns |   5,897 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 129B         |        269.0 ns |       0.87 ns |       1.65 ns |        269.4 ns |   6,264 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        296.7 ns |       0.77 ns |       1.47 ns |        296.7 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        412.9 ns |       0.93 ns |       1.75 ns |        413.0 ns |   8,223 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,997.9 ns |       3.02 ns |       5.36 ns |      1,997.9 ns |   9,550 B |     1224 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        956.9 ns |       4.83 ns |       9.20 ns |        957.4 ns |   5,910 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |        984.0 ns |       4.85 ns |       9.23 ns |        984.3 ns |   6,261 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |      1,056.0 ns |       2.57 ns |       4.89 ns |      1,055.8 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |      1,638.3 ns |       1.34 ns |       2.55 ns |      1,638.6 ns |   8,234 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      5,951.3 ns |      32.60 ns |      59.60 ns |      5,912.2 ns |   9,465 B |     2112 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |      1,059.1 ns |       3.24 ns |       6.16 ns |      1,061.3 ns |   5,891 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |      1,191.2 ns |       3.43 ns |       6.52 ns |      1,192.1 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |      1,844.8 ns |       1.69 ns |       3.21 ns |      1,845.7 ns |   8,229 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |      1,917.0 ns |     586.66 ns |   1,116.19 ns |      1,160.2 ns |   6,257 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      6,891.8 ns |      13.65 ns |      25.63 ns |      6,894.4 ns |   9,487 B |     2120 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      7,306.8 ns |      21.39 ns |      40.70 ns |      7,320.4 ns |   6,159 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |      7,714.0 ns |      21.68 ns |      41.25 ns |      7,712.3 ns |   6,514 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      8,261.2 ns |      36.38 ns |      69.22 ns |      8,240.8 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |     12,664.1 ns |      19.12 ns |      36.39 ns |     12,670.5 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     45,022.3 ns |     129.70 ns |     240.41 ns |     44,905.9 ns |   9,497 B |     9280 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     58,321.7 ns |     129.79 ns |     246.94 ns |     58,320.0 ns |   6,158 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64KB         |     62,642.5 ns |     683.25 ns |   1,299.95 ns |     62,412.1 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     65,934.5 ns |     175.90 ns |     334.68 ns |     65,875.9 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |    101,929.7 ns |     218.91 ns |     416.50 ns |    102,012.6 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    356,629.4 ns |     221.36 ns |     404.78 ns |    356,574.7 ns |   9,489 B |    66624 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |    116,224.3 ns |     202.24 ns |     384.78 ns |    116,361.7 ns |   6,158 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |    127,433.8 ns |   1,475.18 ns |   2,806.68 ns |    127,997.3 ns |   6,510 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |    135,151.3 ns |   2,216.62 ns |   4,217.35 ns |    132,306.2 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |    203,075.4 ns |     266.24 ns |     506.56 ns |    203,265.2 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    776,753.9 ns |   1,419.21 ns |   2,665.63 ns |    778,126.1 ns |   9,521 B |   132174 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    886,864.0 ns |   2,036.73 ns |   3,875.09 ns |    887,814.2 ns |   5,872 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1MB          |  1,027,952.0 ns |  36,500.14 ns |  69,445.32 ns |    995,598.8 ns |   6,247 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |  1,031,422.9 ns |   9,234.76 ns |  17,570.09 ns |  1,039,082.6 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |  1,551,374.1 ns |   2,148.99 ns |   4,036.33 ns |  1,549,908.4 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  5,520,060.7 ns |  15,804.93 ns |  29,295.45 ns |  5,502,105.5 ns |   9,501 B |  1001882 B |
|                                                   |              |                 |               |               |                 |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  8,981,663.5 ns |  37,586.52 ns |  71,512.26 ns |  8,993,810.9 ns |   6,160 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 10MB         |  9,993,129.7 ns |  68,449.88 ns | 130,233.02 ns | 10,042,545.3 ns |   6,533 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         | 10,183,618.2 ns |  24,728.31 ns |  45,835.52 ns | 10,208,271.9 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         | 15,647,476.1 ns |  28,144.35 ns |  53,547.55 ns | 15,662,731.2 ns |   8,499 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 55,912,223.1 ns | 196,941.60 ns | 360,118.88 ns | 55,825,383.3 ns |   9,496 B | 10001157 B |