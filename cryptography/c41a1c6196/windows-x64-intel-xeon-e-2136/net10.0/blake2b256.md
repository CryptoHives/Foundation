| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Median          | Code Size | Allocated  |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 4B           |        141.0 ns |      0.63 ns |      1.20 ns |        140.5 ns |   6,263 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |        149.6 ns |      0.56 ns |      1.05 ns |        150.0 ns |   5,899 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        166.8 ns |      2.17 ns |      4.14 ns |        164.6 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |        212.8 ns |      0.35 ns |      0.66 ns |        212.9 ns |   8,229 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |      1,236.5 ns |      1.98 ns |      3.66 ns |      1,237.1 ns |   8,703 B |     1000 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64B          |        139.1 ns |      1.67 ns |      3.17 ns |        138.3 ns |   6,253 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |        152.7 ns |      3.87 ns |      7.36 ns |        148.2 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        164.3 ns |      2.18 ns |      4.15 ns |        161.9 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |        212.9 ns |      0.90 ns |      1.72 ns |        212.4 ns |   8,232 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |      1,098.3 ns |      2.86 ns |      5.30 ns |      1,097.4 ns |   8,692 B |     1056 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 65B          |        138.5 ns |      0.53 ns |      1.01 ns |        138.8 ns |   6,287 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |        149.4 ns |      1.03 ns |      1.95 ns |        148.8 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        166.0 ns |      2.73 ns |      5.19 ns |        163.0 ns |   6,973 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |        213.2 ns |      0.34 ns |      0.63 ns |        213.3 ns |   8,222 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |      1,097.4 ns |      2.73 ns |      4.99 ns |      1,097.0 ns |   8,745 B |     1064 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |        134.9 ns |      0.76 ns |      1.44 ns |        135.4 ns |   6,245 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |        146.1 ns |      0.50 ns |      0.92 ns |        146.5 ns |   5,916 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |        207.8 ns |      0.69 ns |      1.31 ns |        208.4 ns |   8,218 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        213.2 ns |     33.49 ns |     62.90 ns |        171.6 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        979.1 ns |      1.28 ns |      2.33 ns |        979.6 ns |   8,699 B |     1120 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 129B         |        267.7 ns |      1.09 ns |      2.06 ns |        268.0 ns |   6,257 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        269.6 ns |      1.84 ns |      3.50 ns |        267.9 ns |   5,897 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        290.8 ns |      1.24 ns |      2.34 ns |        290.3 ns |   6,973 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        411.9 ns |      1.03 ns |      1.89 ns |        412.1 ns |   8,223 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,969.9 ns |      5.71 ns |     10.87 ns |      1,973.7 ns |   9,525 B |     1128 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        946.4 ns |      1.48 ns |      2.81 ns |        946.8 ns |   5,915 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |        984.4 ns |      2.56 ns |      4.87 ns |        984.6 ns |   6,254 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |      1,077.2 ns |     22.28 ns |     42.39 ns |      1,050.1 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |      1,641.8 ns |      1.76 ns |      3.30 ns |      1,641.8 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      5,876.2 ns |      6.65 ns |     12.50 ns |      5,876.5 ns |   9,457 B |     2016 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |      1,057.0 ns |      3.07 ns |      5.83 ns |      1,058.7 ns |   5,893 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |      1,181.3 ns |      2.67 ns |      5.01 ns |      1,181.6 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |      1,843.3 ns |      1.59 ns |      2.98 ns |      1,843.0 ns |   8,234 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |      1,863.1 ns |    567.80 ns |  1,080.30 ns |      1,112.2 ns |   6,257 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      6,828.2 ns |      5.28 ns |      9.79 ns |      6,829.6 ns |   9,487 B |     2024 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      7,311.2 ns |     13.10 ns |     24.93 ns |      7,316.8 ns |   6,164 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |      8,229.3 ns |     60.40 ns |    114.92 ns |      8,251.9 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      8,395.0 ns |    153.06 ns |    291.21 ns |      8,242.5 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |     12,692.5 ns |     30.38 ns |     57.81 ns |     12,686.0 ns |   8,480 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     45,078.1 ns |    122.82 ns |    230.68 ns |     45,114.7 ns |   9,497 B |     9184 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     58,095.2 ns |    173.13 ns |    329.39 ns |     58,236.4 ns |   6,164 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64KB         |     63,389.5 ns |    240.56 ns |    457.69 ns |     63,242.3 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     65,903.2 ns |    256.61 ns |    481.98 ns |     65,651.2 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |    101,955.6 ns |    301.09 ns |    565.52 ns |    101,757.3 ns |   8,476 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    365,025.9 ns |  3,041.18 ns |  5,712.07 ns |    361,366.5 ns |   9,479 B |    66528 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |    116,615.3 ns |    391.68 ns |    745.21 ns |    116,602.9 ns |   6,163 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |    124,099.5 ns |    252.62 ns |    480.64 ns |    124,132.6 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |    136,410.4 ns |  3,334.38 ns |  6,262.78 ns |    132,247.0 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |    203,040.0 ns |    176.19 ns |    335.23 ns |    203,085.7 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    775,417.3 ns |  1,042.25 ns |  1,931.88 ns |    776,188.7 ns |   9,482 B |   132078 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    890,343.6 ns |  1,864.00 ns |  3,546.46 ns |    891,621.1 ns |   5,889 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1MB          |    965,871.6 ns |  4,536.96 ns |  8,632.03 ns |    962,114.3 ns |   6,254 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |  1,011,577.3 ns |  2,057.73 ns |  3,915.05 ns |  1,010,064.6 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |  1,548,202.4 ns |  1,076.37 ns |  2,047.91 ns |  1,548,621.1 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  5,528,018.2 ns | 13,265.97 ns | 25,239.89 ns |  5,518,889.1 ns |   9,501 B |  1001757 B |
|                                                   |              |                 |              |              |                 |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  8,979,997.4 ns | 24,864.52 ns | 47,307.34 ns |  8,992,394.5 ns |   6,165 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 10MB         |  9,690,628.4 ns | 32,810.83 ns | 62,426.02 ns |  9,709,359.4 ns |   6,533 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         | 10,189,939.8 ns |  8,532.85 ns | 16,234.63 ns | 10,189,276.6 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         | 15,699,441.0 ns | 41,768.79 ns | 78,451.92 ns | 15,662,846.9 ns |   8,499 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 55,638,733.4 ns | 35,353.49 ns | 66,402.43 ns | 55,630,200.0 ns |   9,496 B | 10001086 B |